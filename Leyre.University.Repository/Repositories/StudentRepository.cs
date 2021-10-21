using Leyre.University.Model.Entities;
using Leyre.University.Repository.Contexts;
using Leyre.University.Repository.Interfaces;
using Leyre.University.Repository.Repositories.Core;

namespace Leyre.University.Repository.Repositories
{
    public class StudentRepository : BaseRepository<StudentModel>, IStudentRepository
    {
        public StudentRepository(UniversityContext universityContext) : base(universityContext)
        {
        }
    }
}
