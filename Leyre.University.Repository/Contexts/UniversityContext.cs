using Leyre.University.Model.Entities;
using Leyre.University.Repository.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Leyre.University.Repository.Contexts
{
    /// <summary>
    /// Context for Database
    /// </summary>
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<EnrollmentModel> Enrollments { get; set; }
        public DbSet<CourseModel> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new StudentMapping());
            modelBuilder.ApplyConfiguration(new EnrollmentMapping());
        }
    }
}
