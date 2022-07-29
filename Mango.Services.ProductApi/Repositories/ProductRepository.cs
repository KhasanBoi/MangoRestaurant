using AutoMapper;
using Mango.Services.ProductApi.Data;
using Mango.Services.ProductApi.Dtos;
using Mango.Services.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ProductDto>> CreateUpdateProduct(ProductDto newProduct)
        {
            var response = new ServiceResponse<ProductDto>();
            var product = _mapper.Map<Product>(newProduct);
            if(product.ProductId > 0)
            {
                _dbContext.Update(product);
            }
            else
            {
                _dbContext.AddAsync(product);
            }
            await _dbContext.SaveChangesAsync();
            response.Data = _mapper.Map<ProductDto>(newProduct);
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteProduct(int productId)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var product = await _dbContext.Products.FirstAsync(p => p.ProductId == productId);
                if(product != null)
                {
                   _dbContext.Products.Remove(product);
                    await _dbContext.SaveChangesAsync();
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Product Not Found";
                }
                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<ProductDto>>> GetProducts()
        {
            var response = new ServiceResponse<IEnumerable<ProductDto>>();
            var products = await _dbContext.Products.ToListAsync();
            response.Data = products.Select(c => _mapper.Map<ProductDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<ProductDto>> GetSingleProduct(int productId)
        {
            var response = new ServiceResponse<ProductDto>();
            var product = await _dbContext.Products.FirstOrDefaultAsync(c => c.ProductId == productId);
            if(product == null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Product Not Found";
                return response;
            }
            response.Data = _mapper.Map<ProductDto>(product);
            return response;
        }
    }
}
