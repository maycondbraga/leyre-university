using Leyre.University.Model.Core;
using Leyre.University.Model.Enums;

namespace Leyre.University.Model.Entities
{
    /// <summary>
    /// Enrollment entity
    /// </summary>
    public class EnrollmentModel : BaseModel
    {
        /// <summary>
        /// Course identifier
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Student identifier
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Grade
        /// </summary>
        public Grade? Grade { get; set; }

        /// <summary>
        /// Course identifier
        /// </summary>
        public CourseModel Course { get; set; }

        /// <summary>
        /// Student entity
        /// </summary>
        public StudentModel Student { get; set; }
    }
}
