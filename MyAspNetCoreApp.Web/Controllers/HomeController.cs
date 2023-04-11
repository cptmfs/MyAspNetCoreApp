using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Filters;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;
using System.Diagnostics;

namespace MyAspNetCoreApp.Web.Controllers
{
    //[Route("[controller]/[action]")] Hybrid kullanım yaptıgımız icin kapatıldı.
    [LogFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        //[Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]  Hybrid kullanım yaptıgımız icin kapatıldı.
        public IActionResult Index()
        {
            var products = _context.Products.OrderByDescending(p => p.Id).Select(x=> new ProductPartialViewModel()
            {
                Id=x.Id,
                Name=x.Name,
                Price=x.Price,
                Stock=x.Stock
            }).ToList();

            ViewBag.ProductListPartialViewModel = new ProductListPartialViewModel()
            {
                Products = products
            };

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            errorViewModel.RequestId= Activity.Current?.Id ?? HttpContext.TraceIdentifier ;


            return View(errorViewModel);
        }
        public IActionResult Visitor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveVisitorComment(VisitorViewModel visitorViewModel)
        {
            try
            {
                var visitor = _mapper.Map<Visitor>(visitorViewModel);
                visitor.Created = DateTime.Now;
                _context.Visitors.Add(visitor);
                _context.SaveChanges();
                TempData["result"] = "Yorum kaydedilmiştir.";
                return RedirectToAction(nameof(HomeController.Visitor));
            }
            catch (Exception)
            {
                TempData["result"] = "Yorum kaydedilirken bir hata meydana geldi.";

                return RedirectToAction(nameof(HomeController.Visitor));

            }
        }
        public IActionResult Remove(int id)
        {
            var visitors = _context.Visitors.Find(id); // Find Metodu Primarkey'e göre bir arama yapıyor.
            _context.Visitors.Remove(visitors);
            _context.SaveChanges();
            return RedirectToAction("Visitor");
        }
    }
}