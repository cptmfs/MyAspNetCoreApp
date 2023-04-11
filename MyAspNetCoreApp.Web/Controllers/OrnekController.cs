using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Filters;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class OrnekController : Controller
    {
        public class Product2
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Images
        {
            public string ChildPng { get; set; }
        }
        [CustomResultFilter("cptmfs","v_CustomResulFilter")]
        public IActionResult Index()
        {
            //ViewBag.name = "Asp.Net Core"; // Taşınacak datayı indexde @ViewBag.name diye çağırabiliyoruz.. 
            //ViewData["age"] = 30;
            //ViewData["names"]= new List<string>() { "Ferit", "Şeyma", "Şimşek" };

            //ViewBag.person = new { Id = 1, name = "ferit", age = 30 };

            //ViewBag.name = "Muhammed Ferit";
            //TempData["surname"] = "Şimşek"; 

            ViewBag.name = "Kurumsal Kaynak Planlama ve Veri Analizi";
            ViewData["unvan"] = "Jr.Software Developer";

            ViewData["lesson"] = new List<string>() { "C#", "Asp.Net MVC", "SQL Server", "HTML/CSS/JS", "OOP", "Flutter" };

            



            var productList = new List<Product2>()
            {
                new(){Id=1,Name="Laptop"},
                new(){Id=2,Name="Televizyon"},
                new(){Id=3,Name="Beyaz Eşya"}
            };




            return View(productList);
        }

        public IActionResult Index2()
        {
            var surname = TempData["surname"];
            ViewBag.name = "Kurumsal Kaynak Planlama ve Veri Analizi";

            ViewData["unvan"] = "Jr.Software Developer";

            var image = new List<Images>()
            {
                new(){ChildPng="Images/8.png"},

            };


            return View(image);
        }

        public IActionResult Index3()
        {
            return RedirectToAction("Index","Ornek"); // Farklı action'a yönlendirme
            //return View();
        }
        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParametre", "Ornek", new { id = id });
        }
        public IActionResult JsonResultParametre(int id)  // json döndüren action 
        {
            return Json(new { Id = id});
        }

        public IActionResult ContentResult()
        {
            return Content("ContentResult"); //string değer gönderen action
        }

        public IActionResult JsonResult()  // json döndüren action 
        {
            return Json(new {Id=1,name="laptop 1",price = 100});
        }

        public IActionResult EmptyResult() // boş ekran getiren action 
        {
            return new EmptyResult();
        }
        
    }
}
