using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;
namespace TaskManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
