using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web2.Controllers
{
    public class LessonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
