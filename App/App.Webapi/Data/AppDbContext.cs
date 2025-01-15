using App.Webapi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Webapi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

        }
        public DbSet<StudentEntity> Students { get; set; }        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());
            modelBuilder.Entity<StudentEntity>().HasData(StudentSeeder.SeedStudents(20).ToArray());
        }
    }
}
