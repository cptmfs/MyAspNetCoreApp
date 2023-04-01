using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;

        private AppDbContext _context;
        private IHelper _helper;
        public ProductsController(AppDbContext context,IHelper helper
            )
        {
            // DI Container
            // Dependency Injection Pattern
            _productRepository = new ProductRepository();
            _context = context;
            _helper= helper;

            //Uygulama her çalıştığında veritabanına yeni kayıt eklememesi için
            //if (!_context.Products.Any()) // Product Tablosunda herhangi bir kayıt varmı ? var ise True döner ve if bloğuna girer. Biz False ise aşağıdaki bloğa girmesini istediğimiz için başına ünlem " ! " koyacağız. Yani Products tablosunda herhangi bir kayıt yoksa aşağıdakileri ekle
            //{
            //    _context.Products.Add(new Product { Name = "Iphone 13 256gb", Price = 31000, Stock = 10 , Color="Blue" });
            //    _context.Products.Add(new Product { Name = "Iphone 13 Pro Max 1TB", Price = 44000, Stock = 15 , Color = "Red"});
            //    _context.Products.Add(new Product { Name = "Iphone 14 Pro Max 1TB", Price = 54000, Stock = 30 , Color = "White"});
            //    _context.SaveChanges();
            //}
            


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
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Discount = new Dictionary<string, int>() 
            {
                {"%10",10 }, 
                {"%15",15},
                {"%20",20},
                {"%30",30 }
            };
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product newProduct) // Tip güvenli sistem.    // 3. YÖNTEM ** Best Practices **
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün Başarıyla Eklendi.";

            return RedirectToAction("Index");
        }
        //[HttpPost]  // 2. YÖNTEM
        //public IActionResult Add(string Name,decimal Price,int Stock,string Color) // Parametre aldığı için method  adını Add yaptık tekrardan. 
        //{
        //    //Request Header-Body 
        //    //Post kullanırsak Body kısmında gider datalar. Kullanıcıdan alınan datalar..
        //    //Get'de ise datalar url de taşınır. buda risklidir..
        //    //2. Yöntem ise Add.cshtml de name="Name" gibi name'lere verdiğimiz isimler'in aynılarını tipleriyle beraber Method'a (SaveProduct) parametre olarak gönderirsek asp.net core bunu otomatik olarak alıyor..


        //    // 1. yöntem ( kullanıcıdan alınan dataları yakalamak için )
        //    //var name =HttpContext.Request.Form["Name"].ToString();
        //    //var price =decimal.Parse(HttpContext.Request.Form["Price"].ToString());
        //    //var stock =int.Parse(HttpContext.Request.Form["Stock"].ToString());
        //    //var color =HttpContext.Request.Form["Color"].ToString();
        //    Product newProduct = new Product()
        //    {
        //        Name = Name,
        //        Price = Price,
        //        Stock = Stock,
        //        Color = Color

        //    };
        //    _context.Products.Add(newProduct);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //[HttpPost]
        //public IActionResult SaveProduct()  // 1. YÖNTEM
        //{

        //    // 1. yöntem ( kullanıcıdan alınan dataları yakalamak için )
        //    var name = HttpContext.Request.Form["Name"].ToString();
        //    var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
        //    var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
        //    var color = HttpContext.Request.Form["Color"].ToString();
        //    Product newProduct = new Product()
        //    {
        //        Name = name,
        //        Price = price,
        //        Stock = stock,
        //        Color = color

        //    };
        //    _context.Products.Add(newProduct);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.Discount = new Dictionary<string, int>()
            {
                {"%10",10 },
                {"%15",15},
                {"%20",20},
                {"%30",30 }
            };
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product updateProduct,int productId)
        {
            updateProduct.Id=productId;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün Başarıyla Güncellendi.";
           
            return RedirectToAction("Index");
        }
    }
}
