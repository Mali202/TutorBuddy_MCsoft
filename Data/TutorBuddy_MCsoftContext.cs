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
            modelBuilder.Entity<ModulesTutored>().HasKey(sc => new { sc.StudentNumber, sc.ModuleID });
            modelBuilder.Entity<ModulesTutored>()
                .HasOne<Tutor>(sc => sc.Tutor)
                .WithMany(s => s.ModulesTutored)
                .HasForeignKey(s => s.StudentNumber);
            modelBuilder.Entity<ModulesTutored>()
                .HasOne<Module>(sc => sc.Module)
                .WithMany(s => s.ModulesTutored)
                .HasForeignKey(s => s.ModuleID);
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<ModulesTutored> ModulesTutored { get; set; }
        public DbSet<IndividualBooking> IndividualBookings { get; set; }
        public DbSet<BankDetails> BankDetails { get; set; }
    }
}
