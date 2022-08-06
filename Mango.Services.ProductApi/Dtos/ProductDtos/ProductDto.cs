using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductApi.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImagUrl { get; set; }
    }
}
