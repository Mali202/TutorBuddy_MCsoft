using Microsoft.EntityFrameworkCore;
using TutorBuddy_MCsoft.Models;

namespace TutorBuddy_MCsoft.Data
{
    public class TutorBuddy_MCsoftContext : DbContext
    {
        public TutorBuddy_MCsoftContext(DbContextOptions<TutorBuddy_MCsoftContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModulesTutored>().HasKey(sc => new { sc.StudentNumber, sc.ModuleCode });
            modelBuilder.Entity<StudentGroupBooking>().HasKey(sc => new { sc.StudentNumber, sc.BookingID });
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<ModulesTutored> ModulesTutored { get; set; }
        public DbSet<IndividualBooking> IndividualBookings { get; set; }
    }
}
