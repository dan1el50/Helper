using AutumnBlazorApp.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutumnBlazorApp.Infrastructure.Data
{
    // This class now handles BOTH Identity tables and your future business tables
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Human> Humans { get; set; }
        // You will add your DbSets for business entities here later, for example:
        // public DbSet<Employee> Employees { get; set; }
        // public DbSet<Department> Departments { get; set; }
    }
}
