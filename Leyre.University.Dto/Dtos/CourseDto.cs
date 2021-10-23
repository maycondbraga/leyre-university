using Leyre.University.Dto.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Leyre.University.Dto.Dtos
{
    public class CourseDto : BaseDto
    {
        /// <summary>
        /// Course title
        /// </summary>
        [Required(ErrorMessage = "The Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// Course credits
        /// </summary>
        [Required(ErrorMessage = "The Credits is required")]
        [Display(Name = "Credits")]
        public int Credits { get; set; }

        /// <summary>
        /// Enrollments list
        /// </summary>
        [Display(Name = "Enrollments")]
        public ICollection<EnrollmentDto> EnrollmentsDto { get; set; }
    }
}
