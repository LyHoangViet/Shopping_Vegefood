using System.ComponentModel.DataAnnotations;

namespace Shoping_vegefood.Models.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Chưa nhập UserName")] 
        public string UserName { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Chưa nhập Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
