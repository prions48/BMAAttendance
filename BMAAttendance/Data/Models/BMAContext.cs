using Microsoft.EntityFrameworkCore;

namespace BMAAttendance.Data.Models
{
    public class BMAContext : DbContext
    {
        public BMAContext(DbContextOptions<BMAContext> options) : base(options)
        {

        }
        public DbSet<BMAUser> BMAUsers { get; set; }
        public DbSet<BMAStudent> BMAStudents { get; set; }
        public DbSet<BMAStudentRank> BMAStudentRanks { get; set; }
        public DbSet<BMARank> BMARanks { get; set; }
        public DbSet<BMAStudentAttend> BMAStudentAttends { get; set; }
        public DbSet<BMASchool> BMASchools { get; set; }
        public DbSet<BMAStudentUser> BMAStudentUsers { get; set; }

        //Navigation Properties are hard :(  )
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BMAStudent>()
            .HasMany(e => e.Attends)
            .WithOne();
        }*/

    }
}