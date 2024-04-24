using BAITAP_BUIVINHTHAI.Model;
using Microsoft.EntityFrameworkCore;

namespace BAITAP_BUIVINHTHAI.data_access
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }

        public DbSet<Company> companies { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
