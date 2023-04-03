using Domain.Models;
using Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{

    public class CamadasContext : DbContext
    {
        public CamadasContext(DbContextOptions<CamadasContext> options) : base(options) { }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(ProfileSeed.Seed);
            modelBuilder.Entity<Employee>().HasData(EmployeeSeed.Seed);
        }
    }
}
