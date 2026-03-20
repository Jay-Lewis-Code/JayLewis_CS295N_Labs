using GC_Board_Game_Cats.Models;
using Microsoft.EntityFrameworkCore;

namespace GC_Board_Game_Cats.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // One DbSet for each domain model class
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure BlogPost to AppUser relationship
            modelBuilder.Entity<BlogPost>()
                .HasOne(b => b.AppUser)
                .WithMany()
                .HasForeignKey(b => b.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
