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
            return View();
        }

        [HttpPost]
        public IActionResult Add(StudentViewModel studentViewModel)
        {
            _context.Students.Add(_mapper.Map<Student>(studentViewModel));
            _context.SaveChanges();
            TempData["status"] = "Ürün Başarıyla Eklendi.";
            return RedirectToAction("Index");
        }
    }
}
