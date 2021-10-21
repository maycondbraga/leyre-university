using Microsoft.AspNetCore.Mvc;
using Leyre.University.Business.Interfaces;
using System.Threading.Tasks;
using Leyre.University.Model.Entities;

namespace Leyre.University.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var listStudents = await studentService.GetAll();
            return View(listStudents);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public async Task<IActionResult> Create(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                student = await studentService.Insert(student);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                NotFound();
            }

            var student = await studentService.GetById(id.Value);

            if (student == null)
            {
                NotFound();
            }

            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                student = await studentService.Update(student);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await studentService.GetById(id.Value);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var student = await studentService.GetById(id.Value);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await studentService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
