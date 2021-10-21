using Leyre.University.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leyre.University.Repository.Mappings
{
    /// <summary>
    /// Student mapping
    /// </summary>
    public class StudentMapping : IEntityTypeConfiguration<StudentModel>
    {
        /// <summary>
        /// Configure for Student entity
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<StudentModel> builder)
        {
            builder.ToTable("TB_STUDENT");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("ID_STUDENT").ValueGeneratedOnAdd();

            builder.Property(t => t.FirstMidName).HasColumnName("DS_FIRST_MID_NAME");
            builder.Property(t => t.LastName).HasColumnName("DS_LAST_NAME");
            builder.Property(t => t.EnrollmentDate).HasColumnName("DT_ENROLLMENT");

            // Mapping Relationship / one-to-many
            builder.HasMany(t => t.Enrollments).WithOne(s => s.Student).HasForeignKey(s => s.StudentId);
        }
    }
}