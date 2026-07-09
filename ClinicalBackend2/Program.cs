using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.Models;
using Domain.IRepository;
using DatabaseLayer.Repository;
using SericeLayer.Account.Rgistration;
using Domain.IUnitOfWork;
using DatabaseLayer.UnitOfWork;
using ServiceLayer.Drug.Interfaces;
using ServiceLayer.Drug;

namespace ClinicalBackend2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            
            // 1. إعداد قاعدة البيانات
            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // 2. إعداد الـ Identity (تم إزالة السطر المتعارض لعدم حدوث Crash)
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            
            // 3. تسجيل المستودعات والخدمات (Dependency Injection)
            builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            builder.Services.AddScoped<IRgistration, Rgistration>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDrugImportService,DrugImportService>();
            builder.Services.AddScoped<IDrugService, DrugService>();
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            builder.Services.AddScoped<IJWTModule, JWTModule>(provider =>
            {
                var config = provider.GetRequiredService<IConfiguration>();
                return new JWTModule(
                    config["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not found in configuration."),
                    config["Jwt:Issuer"] ?? throw new InvalidOperationException("JWT Issuer not found in configuration."),
                    config["Jwt:Audience"] ?? throw new InvalidOperationException("JWT Audience not found in configuration."),
                    int.Parse(config["Jwt:ExpireMinutes"] ?? throw new InvalidOperationException("JWT ExpireMinutes not found in configuration.")),
                    provider.GetRequiredService<IUnitOfWork>()
                );
            }); 

            // 4. إعدادات الـ Authentication والـ JWT
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false, // لو حابب تفعلها خليها true واضبط الـ ValidAudience
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not found in configuration."))
                    )
                };
            });

            var app = builder.Build();

            // إعدادات الـ Pipeline
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/openapi/v1.json", "v1");
                options.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();

            // ترتيب الـ Middleware مهم جداً جداً: Authentication أولاً ثم Authorization
            app.UseAuthentication(); 
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}