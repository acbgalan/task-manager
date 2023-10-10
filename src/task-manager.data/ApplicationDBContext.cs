using Microsoft.EntityFrameworkCore;
using task_manager.data.Models;
using Task = task_manager.data.Models.Task;

namespace task_manager.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>()
                .Property(prop => prop.CreationTime)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}