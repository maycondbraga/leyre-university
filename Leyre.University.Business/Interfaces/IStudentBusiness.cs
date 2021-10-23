using Leyre.University.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leyre.University.Business.Interfaces
{
    public interface IStudentBusiness : IBaseBusiness<StudentModel>
    {
        Task<IEnumerable<CourseModel>> GetCoursesByStudentId(int id);

        new Task<bool> Delete(int id);
    }
}
