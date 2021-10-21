using Leyre.University.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leyre.University.Repository.Mappings
{
    /// <summary>
    /// Course mapping
    /// </summary>
    public class CourseMapping : IEntityTypeConfiguration<CourseModel>
    {
        /// <summary>
        /// Configure for Course entity
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CourseModel> builder)
        {
            builder.ToTable("TB_COURSE");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("ID_COURSE");

            builder.Property(t => t.Title).HasColumnName("DS_TITLE");
            builder.Property(t => t.Credits).HasColumnName("NR_CREDITS");

            // Mapping Relationship / one-to-many
            builder.HasMany(t => t.Enrollments).WithOne(s => s.Course).HasForeignKey(s => s.CourseId);
        }
    }
}
