using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreTraversal.Areas.Admin.Models
{
    public class GuideAddViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen isim soyisim giriniz..")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen açıklama giriniz..")]
        public string Description { get; set; }

        public string TwitterUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string ImageURL { get; set; }

        public IFormFile Image { get; set; }

        public bool Stat { get; set; }
    }
}
