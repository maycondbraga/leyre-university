using Leyre.University.Dto.Core;
using Leyre.University.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace Leyre.University.Dto.Dtos
{
    public class EnrollmentDto : BaseDto
    {
        /// <summary>
        /// Course identifier
        /// </summary>
        [Required(ErrorMessage = "The Course id is required")]
        [Display(Name = "Course Id")]
        public int CourseId { get; set; }

        /// <summary>
        /// Student identifier
        /// </summary>
        [Required(ErrorMessage = "The Student id is required")]
        [Display(Name = "Student Id")]
        public int StudentId { get; set; }

        /// <summary>
        /// Grade
        /// </summary>
        [Display(Name = "Grade")]
        public Grade? Grade { get; set; }

        /// <summary>
        /// Course identifier
        /// </summary>
        public CourseDto Course { get; set; }

        /// <summary>
        /// Student entity
        /// </summary>
        public StudentDto Student { get; set; }
    }
}
