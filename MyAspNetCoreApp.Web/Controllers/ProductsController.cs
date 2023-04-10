using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Controllers
{
    //[Route("[controller]/[action]")] Hybrid kullanım yaptıgımız icin kapatıldı.
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        private AppDbContext _context;
        private IHelper _helper;
        public ProductsController(AppDbContext context, IHelper helper, IMapper mapper)
        {
            // DI Container
            // Dependency Injection Pattern
            _productRepository = new ProductRepository();
            _context = context;
            _helper = helper;
            _mapper = mapper;

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
            return View(_mapper.Map<List<ProductViewModel>>(products));
        }
        [Route("[controller]/[action]/{page}/{pageSize}",Name ="productPage")]
        public IActionResult Pages(int page, int pageSize)
        {
            //page=1 pagesize=3 => ilk 3 kayıt
            //page=2 pagesize=3 => ikinci 3 kayıt
            var products = _context.Products.Skip((page - 1) * pageSize).Take(pageSize).ToList(); //Skip 0 yazınca ilk 3(istediğimiz rakam) kaydı alır eğer 1 yazarsak 1 kayıt atlar sonraki kayıtları alır




            ViewBag.page=page;
            ViewBag.pageSize=pageSize;


            return View(_mapper.Map<List<ProductViewModel>>(products));
        }
        [Route("[action]/{productId}")]

        public IActionResult GetById(int productId)
        {
            var products = _context.Products.Find(productId);

            return View(_mapper.Map<ProductViewModel>(products));
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

            ViewBag.ColorSelect = new SelectList(new List<ColorList>()
            {
                new() {Data="Kırmızı" , Value="Red"},
                new() {Data="Mavi" , Value="Blue"},
                new() {Data="Siyah" , Value="Black"},
                new() {Data="Beyaz" , Value="White"},

            }, "Value", "Data");



            return View();

        }
        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct) // Tip güvenli sistem.    // 3. YÖNTEM ** Best Practices **
        {
            //if (!string.IsNullOrEmpty(newProduct.Name) && newProduct.Name.StartsWith("A")) // eğer ürün adı a ile başlıyorsa
            //{
            //    ModelState.AddModelError(String.Empty, "Ürün ismi A ile Başlayamaz"); // ürün ismi A harfi ile baslayamaz.. ve String.Empty ile herhangi bir başlıgın altında paylaşmayacaksak bu hatayı böyle tanımlıyoruz..
            //}
            ViewBag.Discount = new Dictionary<string, int>()
            {
                {"%10",10 },
                {"%15",15},
                {"%20",20},
                {"%30",30 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorList>()
            {
                new() {Data="Kırmızı" , Value="Red"},
                new() {Data="Mavi" , Value="Blue"},
                new() {Data="Siyah" , Value="Black"},
                new() {Data="Beyaz" , Value="White"},

            }, "Value", "Data");



            if (ModelState.IsValid) // Validasyon başarılı ise aşağıdaki kaydetmeyi yap..
            {
                //Modelstate valid geldiyse yani validasyon başarılı ise yinede veritabanına kayıt anında bir hata olusabilir diye try catch bloguyla kontrol edelim.
                try
                {
                    _context.Products.Add(_mapper.Map<Product>(newProduct));
                    _context.SaveChanges();
                    TempData["status"] = "Ürün Başarıyla Eklendi.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ürün kaydedilirken bir hata meydana geldi. Lütfen daha sonra tekrar deneyiniz.");
                    return View();
                }


            }
            else
            {
                return View();
            }

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
            ViewBag.ColorSelect = new SelectList(new List<ColorList>()
            {
                new() {Data="Kırmızı" , Value="Red"},
                new() {Data="Mavi" , Value="Blue"},
                new() {Data="Siyah" , Value="Black"},
                new() {Data="Beyaz" , Value="White"},

            }, "Value", "Data", product.Color);

            return View(_mapper.Map<ProductViewModel>(product));
        }
        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.Discount = new Dictionary<string, int>()
            {
                {"%10",10 },
                {"%15",15},
                {"%20",20},
                {"%30",30 }
            };
                ViewBag.ColorSelect = new SelectList(new List<ColorList>()
            {
                new() {Data="Kırmızı" , Value="Red"},
                new() {Data="Mavi" , Value="Blue"},
                new() {Data="Siyah" , Value="Black"},
                new() {Data="Beyaz" , Value="White"},

            }, "Value", "Data", updateProduct.Color);

                return View();
            }
            _context.Products.Update(_mapper.Map<Product>(updateProduct));
            _context.SaveChanges();
            TempData["status"] = "Ürün Başarıyla Güncellendi.";

            return RedirectToAction("Index");
        }
        [AcceptVerbs("GET","POST")] // Hem get hem post olabilir..
        public IActionResult HasProductName(string Name)
        {
            var anyProduct = _context.Products.Any(x => x.Name.ToLower() == Name.ToLower());
            if (anyProduct) // anyProduct True geldiyse ..
            {
                return Json("Kaydetmeye çalıştığınızÜrün ismi veritabanında bulunmaktadır..");
            }
            else
            {
                return Json(true); // validasyondan geçti demek için true.
            }


        }
    }
}
