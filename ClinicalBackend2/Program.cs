using System.Text;
using DatabaseLayer;
using DatabaseLayer.Repository;
using DatabaseLayer.UnitOfWork;
using Domain.IRepository;
using Domain.IUnitOfWork;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SericeLayer.Account.Login;
using SericeLayer.Account.Rgistration;
using ServiceLayer.Drug;
using ServiceLayer.Drug.Interfaces;
using ServiceLayer.JWT;
using ServiceLayer.Patient;
using ServiceLayer.Appointment;


namespace ClinicalBackend2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IPatient,ServiceLayer.Patient.Patient>();
            builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            builder.Services.AddScoped<IRgistration, Rgistration>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ILogin, Login>();
            builder.Services.AddScoped<IDrugService, DrugService>();
            builder.Services.AddScoped<IDrugImportService, DrugImportService>();
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IAppointmentService , AppointmentService>();
            builder.Services.AddScoped<IAppoinmentRepository, AppoinmentRepository>();

            builder.Services.AddSignalR();
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
                    ValidateAudience = false, 
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
            
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/openapi/v1.json", "v1");
                options.RoutePrefix = "swagger";
                });
            }
            
            app.MapHub<chat>("/chat");

            app.UseHttpsRedirection();
            app.UseAuthentication(); 
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}