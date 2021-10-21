using Leyre.University.Business.Core;
using Leyre.University.Business.Interfaces;
using Leyre.University.Model.Entities;
using Leyre.University.Repository.Interfaces;

namespace Leyre.University.Business.Rules
{
    public class StudentService : BaseService<StudentModel>, IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository) : base(studentRepository)
        {
            this.studentRepository = studentRepository;
        }
    }
}
