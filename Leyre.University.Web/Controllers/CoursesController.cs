using Microsoft.AspNetCore.Mvc;
using Leyre.University.Business.Interfaces;
using System.Threading.Tasks;
using Leyre.University.Dto.Dtos;
using Leyre.University.Model.Entities;
using AutoMapper;
using System.Linq;

namespace Leyre.University.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseBusiness courseBusiness;
        private readonly IMapper mapper;

        public CoursesController(ICourseBusiness courseBusiness, IMapper mapper)
        {
            this.courseBusiness = courseBusiness;
            this.mapper = mapper;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var dataCourses = await courseBusiness.GetAll();

            var listCourses = dataCourses.Select(x => mapper.Map<CourseDto>(x)).ToList();

            return View(listCourses);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseModel = await courseBusiness.GetById(id.Value);

            if (courseModel == null)
            {
                return NotFound();
            }

            var courseDto = mapper.Map<CourseDto>(courseModel);

            return View(courseDto);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Credits,Id")] CourseDto courseDto)
        {
            if (ModelState.IsValid)
            {
                var courseModel = mapper.Map<CourseModel>(courseDto);

                await courseBusiness.Insert(courseModel);

                return RedirectToAction("Index");
            }

            return View(courseDto);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseModel = await courseBusiness.GetById(id.Value);

            if (courseModel == null)
            {
                return NotFound();
            }

            var courseDto = mapper.Map<CourseDto>(courseModel);

            return View(courseDto);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Credits,Id")] CourseDto courseDto)
        {
            if (ModelState.IsValid)
            {
                var courseModel = mapper.Map<CourseModel>(courseDto);

                await courseBusiness.Update(courseModel);

                return RedirectToAction("Index");
            }

            return View(courseDto);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseModel = await courseBusiness.GetById(id.Value);

            if (courseModel == null)
            {
                NotFound();
            }

            var courseDto = mapper.Map<CourseDto>(courseModel);

            return View(courseDto);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await courseBusiness.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
