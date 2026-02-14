using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserTask> UserTasks { get; set; }
    }
}
