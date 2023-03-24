using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ExampleController : Controller
    {
        public class MyViewModel
        {
            public string LinkedInUrl { get; set; }
            public string GithubUrl { get; set; }
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NoLayout()
        {
            return View();
        }
        public IActionResult Social()
        {
            var social = new List<MyViewModel>()
            {
                new () {LinkedInUrl="http://www.linkedin.com/in/muhammed-ferit-simsek-119550217"},
                new () {GithubUrl="http://github.com/cptmfs"}
            };
            return View(social);
        }
    }
}
