using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductApi.Dtos
{
    public class ProductDto
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Range(1, 1000)]
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImagUrl { get; set; }
    }
}
