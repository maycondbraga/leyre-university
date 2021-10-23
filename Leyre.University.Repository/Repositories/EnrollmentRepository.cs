using Leyre.University.Model.Entities;
using Leyre.University.Repository.Contexts;
using Leyre.University.Repository.Interfaces;
using Leyre.University.Repository.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leyre.University.Repository.Repositories
{
    public class EnrollmentRepository : BaseRepository<EnrollmentModel>, IEnrollmentRepository
    {
        private readonly UniversityContext universityContext;

        public EnrollmentRepository(UniversityContext universityContext) : base(universityContext)
        {
            this.universityContext = universityContext;
        }

        public new async Task<List<EnrollmentModel>> GetAll()
        {
            var listEnrollments = await universityContext.Enrollments.Include(x => x.Course)
                .Include(x => x.Student)
                .ToListAsync();

            return listEnrollments;
        }
    }
}
