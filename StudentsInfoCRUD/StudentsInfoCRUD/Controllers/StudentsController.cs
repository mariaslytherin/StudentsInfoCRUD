using Microsoft.AspNetCore.Mvc;
using StudentsInfoCRUD.Data;
using StudentsInfoCRUD.Data.Entities;

namespace StudentsInfoCRUD.Controllers
{
    public class StudentsController : Controller
    {
        private AppDbContext _appDbContext;

        public StudentsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
           _appDbContext.Students.Add(student);
            _appDbContext.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List()
        {
            var students = _appDbContext.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _appDbContext.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            var oldStudent = _appDbContext.Students.Find(student.Id);
            oldStudent.FirstName = student.FirstName;
            oldStudent.LastName = student.LastName;
            oldStudent.FacultyNumber = student.FacultyNumber;
            oldStudent.Faculty = student.Faculty;
            _appDbContext.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _appDbContext.Students.Find(id);
            _appDbContext.Students.Remove(student);
            _appDbContext.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
