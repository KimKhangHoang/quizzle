using Microsoft.EntityFrameworkCore;
using Quizzle.Models;

namespace Quizzle.Data
{
    public class QuizzleContext : DbContext
    {
        public QuizzleContext(DbContextOptions<QuizzleContext> options) : base(options) { }

        public DbSet<Question> Questions { get; set; }

        // Ensure the 'Id' property is the primary key of type Guid
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasKey(q => q.Id);
        }
    }
}