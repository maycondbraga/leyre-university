using System;
using System.Collections.Generic;
using Leyre.University.Model.Core;

namespace Leyre.University.Model.Entities
{
    /// <summary>
    /// Student entity
    /// </summary>
    public class StudentModel : BaseModel
    {
        /// <summary>
        /// First name
        /// </summary>
        public string FirstMidName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Enrollment Date
        /// </summary>
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// EnrollmentModel entity
        /// </summary>
        public ICollection<EnrollmentModel> Enrollments { get; set; }
    }
}