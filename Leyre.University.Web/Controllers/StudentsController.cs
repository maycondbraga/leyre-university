using Microsoft.AspNetCore.Mvc;
using Leyre.University.Business.Interfaces;
using System.Threading.Tasks;
using Leyre.University.Dto.Dtos;
using Leyre.University.Model.Entities;
using AutoMapper;
using System.Linq;

namespace Leyre.University.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentBusiness studentBusiness;
        private readonly IMapper mapper;

        public StudentsController(IStudentBusiness studentBusiness, IMapper mapper)
        {
            this.studentBusiness = studentBusiness;
            this.mapper = mapper;
        }

        // GET: Students
        public async Task<IActionResult> Index(int? id)
        {
            var dataStudents = await studentBusiness.GetAll();

            var listStudents = dataStudents.Select(x => mapper.Map<StudentDto>(x)).ToList();

            if (id != null)
            {
                ViewBag.Courses = await studentBusiness.GetCoursesByStudentId(id.Value);
            }

            return View(listStudents);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public async Task<IActionResult> Create(StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                var studentModel = mapper.Map<StudentModel>(studentDto);

                await studentBusiness.Insert(studentModel);

                return RedirectToAction("Index");
            }

            return View(studentDto);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                NotFound();
            }

            var studentModel = await studentBusiness.GetById(id.Value);

            if (studentModel == null)
            {
                NotFound();
            }

            var studentDto = mapper.Map<StudentDto>(studentModel);

            return View(studentDto);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                var studentModel = mapper.Map<StudentModel>(studentDto);

                await studentBusiness.Update(studentModel);

                return RedirectToAction("Index");
            }

            return View(studentDto);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await studentBusiness.GetById(id.Value);

            if (studentModel == null)
            {
                NotFound();
            }

            var studentDto = mapper.Map<StudentDto>(studentModel);

            return View(studentDto);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await studentBusiness.GetById(id.Value);

            if (studentModel == null)
            {
                NotFound();
            }

            var studentDto = mapper.Map<StudentDto>(studentModel);

            return View(studentDto);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await studentBusiness.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
