using AutoMapper;
using Leyre.University.Business.Interfaces;
using Leyre.University.Dto.Dtos;
using Leyre.University.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Leyre.University.Web.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IEnrollmentBusiness enrollmentBusiness;
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

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enrollments/Create
        [HttpPost]
        public async Task<IActionResult> Create(EnrollmentDto enrollmentDto)
        {
            if (ModelState.IsValid)
            {
                var enrollmentModel = mapper.Map<EnrollmentModel>(enrollmentDto);

                await enrollmentBusiness.Insert(enrollmentModel);

                return RedirectToAction("Index");
            }

            return View(enrollmentDto);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                NotFound();
            }

            var enrollmentModel = await enrollmentBusiness.GetById(id.Value);

            if (enrollmentModel == null)
            {
                NotFound();
            }

            var enrollmentDto = mapper.Map<EnrollmentDto>(enrollmentModel);

            return View(enrollmentDto);
        }

        // POST: Enrollments/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(EnrollmentDto enrollmentDto)
        {
            if (ModelState.IsValid)
            {
                var enrollmentModel = mapper.Map<EnrollmentModel>(enrollmentDto);

                await enrollmentBusiness.Update(enrollmentModel);

                return RedirectToAction("Index");
            }

            return View(enrollmentDto);
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentModel = await enrollmentBusiness.GetById(id.Value);

            if (enrollmentModel == null)
            {
                NotFound();
            }

            var enrollmentDto = mapper.Map<EnrollmentDto>(enrollmentModel);

            return View(enrollmentDto);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentModel = await enrollmentBusiness.GetById(id.Value);

            if (enrollmentModel == null)
            {
                NotFound();
            }

            var enrollmentDto = mapper.Map<EnrollmentDto>(enrollmentModel);

            return View(enrollmentDto);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await enrollmentBusiness.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
