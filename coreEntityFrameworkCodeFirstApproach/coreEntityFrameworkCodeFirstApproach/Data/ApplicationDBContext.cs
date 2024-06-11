using coreEntityFrameworkCodeFirstApproach.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace coreEntityFrameworkCodeFirstApproach.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=Customer; username=postgres; password=postgres");
        }
    }
}
