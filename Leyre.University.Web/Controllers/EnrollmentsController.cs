using AutoMapper;
using Leyre.University.Business.Interfaces;
using Leyre.University.Dto.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Leyre.University.Web.Controllers
{
    public class EnrollmentsController : Controller
    {
        private IEnrollmentBusiness enrollmentBusiness;
        private readonly IMapper mapper;

        public EnrollmentsController(IEnrollmentBusiness enrollmentBusiness, IMapper mapper)
        {
            this.enrollmentBusiness = enrollmentBusiness;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var dataEnrollments = await enrollmentBusiness.GetAll();

            var listEnrollments = dataEnrollments.Select(x => mapper.Map<EnrollmentDto>(x)).ToList();

            return View(listEnrollments);
        }
    }
}
