using Leyre.University.Business.Core;
using Leyre.University.Business.Interfaces;
using Leyre.University.Model.Entities;
using Leyre.University.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leyre.University.Business.Rules
{
    public class StudentBusiness : BaseBusiness<StudentModel>, IStudentBusiness
    {
        private readonly IStudentRepository studentRepository;

        public StudentBusiness(IStudentRepository studentRepository) : base(studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<IEnumerable<CourseModel>> GetCoursesByStudentId(int id)
        {
            return await studentRepository.GetCoursesByStudentId(id);
        }
    }
}
