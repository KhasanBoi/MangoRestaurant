using Mango.Services.ProductApi.Dtos.ProductDtos;

namespace Mango.Services.ProductApi.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();

        Task<ProductDto> GetProductById(int id);

        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);

        Task<bool> DeleteProduct(int id);
    }
}
