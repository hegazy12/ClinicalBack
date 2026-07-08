using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DatabaseLayer
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Test> Tests { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }
          
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        var connectionString = "Data Source=RUE-LAP\\SQLEXPRESS;Database=ClinicalBackend2;Integrated Security=True;Trust Server Certificate=True;";
        //        if (!string.IsNullOrWhiteSpace(connectionString))
        //        {
        //            optionsBuilder.UseSqlServer(connectionString);
        //        }
        //    }
        //}
          
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here
            base.OnModelCreating(modelBuilder);
        }
    }
}