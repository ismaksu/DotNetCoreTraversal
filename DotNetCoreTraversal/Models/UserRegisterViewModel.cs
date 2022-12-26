using System.ComponentModel.DataAnnotations;

namespace DotNetCoreTraversal.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage = "Lütfen adınızı giriniz.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
		public string Mail { get; set; }

		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz.")]
		[Compare("Password", ErrorMessage = "Girdiğiniz şifreler uyuşmuyor.")]
		public string ConfirmPassword { get; set; }
	}
}
