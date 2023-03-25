using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;

        private AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            // DI Container
            // Dependency Injection Pattern
            _productRepository = new ProductRepository();
            _context = context;

            //Uygulama her çalıştığında veritabanına yeni kayıt eklememesi için
            if (!_context.Products.Any()) // Product Tablosunda herhangi bir kayıt varmı ? var ise True döner ve if bloğuna girer. Biz False ise aşağıdaki bloğa girmesini istediğimiz için başına ünlem " ! " koyacağız. Yani Products tablosunda herhangi bir kayıt yoksa aşağıdakileri ekle
            {
                _context.Products.Add(new Product { Name = "Iphone 13 256gb", Price = 31000, Stock = 10 , Color="Blue" });
                _context.Products.Add(new Product { Name = "Iphone 13 Pro Max 1TB", Price = 44000, Stock = 15 , Color = "Red"});
                _context.Products.Add(new Product { Name = "Iphone 14 Pro Max 1TB", Price = 54000, Stock = 30 , Color = "White"});
                _context.SaveChanges();
            }
            


            //if (!_productRepository.GetAll().Any()) // Any içerisinde herhangi bi data yoksa aşağıdakileri ekle.. ! ile 
            //{
                
            //}

        }

        public IActionResult Index()
        {
            //var products = _productRepository.GetAll();
            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Remove(int id)
        {
            //_productRepository.Remove(id);

            var product = _context.Products.Find(id); // Find Metodu Primarkey'e göre bir arama yapıyor.
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Update(int id)
        {
            return View();
        }
    }
}
