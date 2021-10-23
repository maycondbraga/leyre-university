using Leyre.University.Model.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leyre.University.Model.Entities
{
    /// <summary>
    /// Course entity
    /// </summary>
    public class CourseModel : BaseModel
    {
        /// <summary>
        /// Id for entity
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new int Id { get; set; }

        /// <summary>
        /// Course title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Course credits
        /// </summary>
        public int Credits { get; set; }

        /// <summary>
        /// Enrollments list
        /// </summary>
        public ICollection<EnrollmentModel> Enrollments { get; set; }
    }
}