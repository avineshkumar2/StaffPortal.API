using Microsoft.EntityFrameworkCore;
using StaffPortal.API.Models;

namespace StaffPortal.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSet properties for each entity
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints here if needed
            modelBuilder.Entity<Staff>()
            .HasIndex(s => s.EmployeeNumber)
            .IsUnique();

        }
    }
}
