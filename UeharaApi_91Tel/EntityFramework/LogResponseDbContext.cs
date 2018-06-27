
using Microsoft.EntityFrameworkCore;
using UeharaApi_91Tel.Models;

namespace UeharaApi_91Tel.EntityFramework
{
    public class LogResponseDbContext : DbContext
    {
        public LogResponseDbContext(DbContextOptions<LogResponseDbContext> options)
            : base(options)
        { }
        public DbSet<LogResponse> LogModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
