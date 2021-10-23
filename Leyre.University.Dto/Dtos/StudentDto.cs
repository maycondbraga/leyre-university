using System;
using Leyre.University.Dto.Core;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Leyre.University.Dto.Dtos
{
    /// <summary>
    /// Student Dto
    /// </summary>
    public class StudentDto : BaseDto
    {
        /// <summary>
        /// Student Id
        /// </summary>
        [Display(Name = "Student Id")]
        public new int Id { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [Required(ErrorMessage = "The Fist Name is required")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        [Required(ErrorMessage = "The Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Enrollment Date
        /// </summary>
        [Required(ErrorMessage = "The Enrollment Date is required")]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// EnrollmentDto entity
        /// </summary>
        [Display(Name = "Enrollments")]
        public ICollection<EnrollmentDto> Enrollments { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get { return FirstMidName + " " + LastName; } }
    }
}
