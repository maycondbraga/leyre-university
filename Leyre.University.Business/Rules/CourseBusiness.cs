using Leyre.University.Business.Core;
using Leyre.University.Business.Interfaces;
using Leyre.University.Model.Entities;
using Leyre.University.Repository.Interfaces;

namespace Leyre.University.Business.Rules
{
    public class CourseBusiness : BaseBusiness<CourseModel>, ICourseBusiness
    {
        private readonly ICourseRepository courseRepository;

        public CourseBusiness(ICourseRepository courseRepository) : base(courseRepository)
        {
            this.courseRepository = courseRepository;
        }
    }
}
