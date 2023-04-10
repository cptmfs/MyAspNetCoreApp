using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class BlogController : Controller
    {
        [Route("blog/bloglar/{name}/{id}")] //[Route("/{name}/{id}")] 
        public IActionResult Article(string name,int id) //blog/article/makale-ismi/id
        {
            //var routes = Request.RouteValues["article"];
            return View();
        }

    }
}
