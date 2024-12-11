using Microsoft.EntityFrameworkCore;
using SimpleJobAPI.Models;

namespace SimpleJobAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<JobAssignment> JobAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobAssignment>()
                .HasKey(ja => new { ja.JobID, ja.UserID });

            modelBuilder.Entity<JobAssignment>()
                .HasOne(ja => ja.Job)
                .WithMany(j => j.AssignedUsers)
                .HasForeignKey(ja => ja.JobID);

            modelBuilder.Entity<JobAssignment>()
                .HasOne(ja => ja.User)
                .WithMany(u => u.AssignedJobs)
                .HasForeignKey(ja => ja.UserID);
            
           
        }
    }
}
