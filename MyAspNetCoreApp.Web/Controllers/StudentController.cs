using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class StudentController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(_mapper.Map<List<StudentViewModel>>(students));
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(StudentViewModel studentViewModel)
        {
            _context.Students.Add(_mapper.Map<Student>(studentViewModel));
            _context.SaveChanges();
            TempData["status"] = "Öğrenci Bilgileri Başarıyla Eklendi.";
            return RedirectToAction("Index");
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult List(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Where(x => x.Id ==student.Id).ToList();
            return View(_mapper.Map<StudentViewModel>(student));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = _context.Students.Find(id);

            return View(_mapper.Map<StudentViewModel>(student));
        }
        [HttpPost]

        public IActionResult Update(StudentViewModel studentViewModel)
        {
            _context.Update(_mapper.Map<Student>(studentViewModel));
            _context.SaveChanges();
            TempData["status"] = "Öğrenci Bilgileri Başarıyla Güncellendi.";
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
