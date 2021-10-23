using Leyre.University.Model.Entities;
using Leyre.University.Repository.Interfaces.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leyre.University.Repository.Interfaces
{
    public interface IStudentRepository : IBaseRepository<StudentModel>
    {
        Task<IEnumerable<CourseModel>> GetCoursesByStudentId(int id);

        new Task<bool> Delete(int id);
    }
}
