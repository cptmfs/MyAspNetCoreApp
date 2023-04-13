using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Web.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim alanı boş olamaz!")]
        [StringLength(30, ErrorMessage = "İsim alanına max 30 karakter girilebilir!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisim alanı boş olamaz!")]
        [StringLength(30, ErrorMessage = "Soyisim alanına max 30 karakter girilebilir!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Resim alanı boş olamaz!")]
        [Url(ErrorMessage = "Lütfen geçerli bir url giriniz!")]

        public string Image { get; set; }
        [Required(ErrorMessage = "LinkedIn profil alanı boş olamaz!")]
        [Url(ErrorMessage = "Lütfen geçerli bir url giriniz!")]
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        public string Twitter { get; set; }
        [Required(ErrorMessage = "Doğum Tarihi bilgisi boş olamaz!")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Doğum Yeri bilgisi boş olamaz!")]
        [StringLength(20,ErrorMessage ="Doğum yeri bilgisi max 20 karakter girilebilir!")]
        public string PlaceOfBirth { get; set; }
        public string Title { get; set; }
        public string Experiences { get; set; }
        public string Skills { get; set; }
    }
}
