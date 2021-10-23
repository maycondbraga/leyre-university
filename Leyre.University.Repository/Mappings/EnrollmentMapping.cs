using Leyre.University.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leyre.University.Repository.Mappings
{
    /// <summary>
    /// Enrollment mapping
    /// </summary>
    public class EnrollmentMapping : IEntityTypeConfiguration<EnrollmentModel>
    {
        /// <summary>
        /// Configure for Enrollment entity
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<EnrollmentModel> builder)
        {
            builder.ToTable("TB_ENROLLMENT");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID_ENROLLMENT").ValueGeneratedOnAdd();

            builder.Property(t => t.CourseId).HasColumnName("ID_COURSE");
            builder.Property(t => t.StudentId).HasColumnName("ID_STUDENT");
            builder.Property(t => t.Grade).HasColumnName("DS_GRADE").HasColumnType("char");
        }
    }
}