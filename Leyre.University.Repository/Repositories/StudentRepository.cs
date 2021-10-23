using Leyre.University.Model.Entities;
using Leyre.University.Repository.Contexts;
using Leyre.University.Repository.Interfaces;
using Leyre.University.Repository.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leyre.University.Repository.Repositories
{
    public class StudentRepository : BaseRepository<StudentModel>, IStudentRepository
    {
        private readonly UniversityContext universityContext;

        public StudentRepository(UniversityContext universityContext) : base(universityContext)
        {
            this.universityContext = universityContext;
        }

        public async Task<IEnumerable<CourseModel>> GetCoursesByStudentId(int id)
        {

            var listCourses = await universityContext.Enrollments
                .Include(x => x.Course)
                .Where(x => x.StudentId == id)
                .Select(x => x.Course)
                .ToListAsync();

            return listCourses;
        }

        public new async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            var flag = universityContext.Enrollments.Any(x => x.StudentId == id);

            if (flag)
                throw new Exception("The student have enrollments");

            universityContext.Students.Remove(entity);
            await universityContext.SaveChangesAsync();
        }
    }
}
