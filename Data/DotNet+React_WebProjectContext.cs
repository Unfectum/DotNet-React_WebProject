using Microsoft.EntityFrameworkCore;
using DotNet_React_WebProject.Models;

namespace DotNet_React_WebProject.Data
{
    public class DotNet_React_WebProjectContext : DbContext
    {
        public DotNet_React_WebProjectContext(DbContextOptions<DotNet_React_WebProjectContext> options)
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Request> Request { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Topic>()
                .HasOne(p => p.Course)
                .WithMany(b => b.Topics)
                .HasForeignKey(r => r.CourseId);
                

            modelBuilder.Entity<Course>()
                .HasMany(p => p.Users)
            .WithMany(p => p.Courses)
            .UsingEntity<Request>(
                j => j
                    .HasOne(pt => pt.User)
                    .WithMany(t => t.Requests)
                    .HasForeignKey(pt => pt.UserId),
                j => j
                    .HasOne(pt => pt.Course)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(pt => pt.CourseId),
                j =>
                {
                    j.HasKey(t => new { t.CourseId, t.UserId });
                });
            modelBuilder.Entity<Request>()
                .Property(b => b.IsConfirmed)
                .HasDefaultValue(false);
        }
    }
}
