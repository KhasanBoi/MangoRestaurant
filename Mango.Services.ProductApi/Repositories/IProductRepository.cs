using Mango.Services.ProductApi.Dtos;
using Mango.Services.ProductApi.Models;

namespace Mango.Services.ProductApi.Repositories
{
    public interface IProductRepository
    {
        Task<ServiceResponse<IEnumerable<ProductDto>>> GetProducts();
        Task<ServiceResponse<ProductDto>> GetSingleProduct(int productId);
        Task<ServiceResponse<ProductDto>> CreateUpdateProduct(ProductDto newProduct);
        Task<ServiceResponse<bool>> DeleteProduct(int productId);
    }
}
