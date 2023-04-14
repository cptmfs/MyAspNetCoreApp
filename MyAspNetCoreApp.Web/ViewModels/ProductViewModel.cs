using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="İsim alanı boş olamaz!")]
        [StringLength(50,ErrorMessage ="İsim alanına max 50 karakter girilebilir!")]
        [Remote("HasProductName",controller: "Products")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Fiyat alanı boş olamaz!")]
        [Range(1, 1000000, ErrorMessage = "Fiyat 1 ile 1000000 ₺ arası olmalıdır!")]
        [RegularExpression(@"^(\d+(?:,\d{1,2})?).*", ErrorMessage ="Fiyat alanında noktadan sonra 2 basamak olmalıdır!")]
        public decimal? Price { get; set; } // Required Attribute kullandıgımız tip value ise nullable yapmak zorundayız
        [Required(ErrorMessage = "Stok alanı boş olamaz!")]
        [Range(1,200,ErrorMessage = "Stok miktarı 1 ile 200 arası olmalıdır!")]

        public int? Stock { get; set; }
        [Required(ErrorMessage = "Açıklama alanı boş olamaz!")]
        [StringLength(500,MinimumLength =10, ErrorMessage = "İsim alanına min 10  , max 500 karakter girilebilir!")]

        public string Description { get; set; }
        [Required(ErrorMessage = "Renk seçiniz!")]

        public string? Color { get; set; } // ?  = nullable 
        [Required(ErrorMessage = "Yayınlanma tarihi boş olamaz!")]

        public DateTime? PublishDate { get; set; }
        public bool IsPublish { get; set; }
        public int? Discount { get; set; }
        [ValidateNever]
        public IFormFile? Image { get; set; }
        [ValidateNever] //Bu işlemi bir validasyondan geçirme..
        public string? ImagePath { get; set; }
        [Required(ErrorMessage = "Kategori seçiniz!")]

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
