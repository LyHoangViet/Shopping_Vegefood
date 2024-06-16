using System.ComponentModel.DataAnnotations;

namespace Shoping_vegefood.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Chưa nhập UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Chưa nhập Email"),EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Chưa nhập Password")]
        public string Password { get; set; }
    }
}
