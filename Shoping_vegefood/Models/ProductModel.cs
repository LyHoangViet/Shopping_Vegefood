using System.ComponentModel.DataAnnotations;

namespace Shoping_vegefood.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên sản phẩm")]
        public string Name { get; set; }
        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên sản phẩm")]
        public string Description { get; set; }
        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập giá sản phẩm")]
        public decimal Price { get; set; }
        [Required]
        public string Slug { get; set; }
        public int BrandId { get; set; }
        public int ShopId { get; set; }
        public ShopModel Shop { get; set; }
        public BrandModel Brand { get; set; }
        public string Image { get; set; }

    }
}
