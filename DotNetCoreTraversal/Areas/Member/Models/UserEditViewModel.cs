using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreTraversal.Areas.Member.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Lütfen isminizi giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyisminizi giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen bir resim yolu giriniz.")]
        public string ImageUrl { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Lütfen yeni mail adresinizi giriniz.")]
        public string Email { get; set; }

        public IFormFile Image { get; set; }
    }
}
