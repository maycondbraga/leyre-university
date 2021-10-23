using Leyre.University.Business.Core;
using Leyre.University.Business.Interfaces;
using Leyre.University.Model.Entities;
using Leyre.University.Repository.Interfaces;

namespace Leyre.University.Business.Rules
{
    public class EnrollmentBusiness : BaseBusiness<EnrollmentModel>, IEnrollmentBusiness
    {
        private readonly IEnrollmentRepository enrollmentRepository;

        public EnrollmentBusiness(IEnrollmentRepository enrollmentRepository) : base(enrollmentRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
        }
    }
}
