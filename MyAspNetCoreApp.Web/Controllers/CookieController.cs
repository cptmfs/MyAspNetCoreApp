using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult CookieCreate()
        {
            //Cookie kaydederken context'in response'ından kaydediyoruz
            HttpContext.Response.Cookies.Append("background-color", "red", new CookieOptions()
            {
                Expires=DateTime.Now.AddDays(2) 
            });
            return View();
        }
        public IActionResult CookieRead()
        {
            //Cookie okurken context'in request'inden kaydediryoruz

            var bgcolor = HttpContext.Request.Cookies["background-color"];
            ViewBag.bgcolor=bgcolor;
            return View();
        }
    }
}
