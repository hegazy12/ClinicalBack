using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Models;


namespace DatabaseLayer
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
    public DbSet<Test> Tests { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
     public DbSet<Drug> Drugs { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }
          
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if (!optionsBuilder.IsConfigured)
           {
                var connectionString = "Data Source=RUE-LAP\\SQLEXPRESS;Database=ClinicalBackend2;Integrated Security=True;Trust Server Certificate=True;";
                //var connectionString = "Server=localhost,1433;Database=mvcx;User Id=sa;Password=Abdo7gazy123456##AS;TrustServerCertificate=True;";
                if (!string.IsNullOrWhiteSpace(connectionString))
               {
                   optionsBuilder.UseSqlServer(connectionString);
               }
           }
        }
          
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here
            base.OnModelCreating(modelBuilder);
        }
    }
}