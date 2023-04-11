using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Filters
{
    public class NotFoundFilter: ActionFilterAttribute
    {
        AppDbContext _context;

        public NotFoundFilter(AppDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var idValue = context.ActionArguments.Values.First(); //ActionArguments action methodların aldıgı parametreler. Onlardan birinciyi al dedik.

            var id = (int)idValue; //obje olarak geldiği için int dönüsümü yaptık

            var hasProduct = _context.Products.Any(x => x.Id == id); //veritabanında id kontrol ettik eşleşirse true dönecek.

            if (hasProduct==false) // eger eslesmediyse bu id yok demektir. o zaman error sayfasına yönlendirme yapacagız.
            {
                context.Result=new RedirectToActionResult("Error","Home",new ErrorViewModel()
                {
                    Errors=new List<string>() { $"Id({id})'ye sahip ürün veritabanında bulunamamıştır."}
                });
            }
        }
    }
}
