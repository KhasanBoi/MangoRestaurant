using AutoMapper;
using Mango.Services.ProductApi.Data;
using Mango.Services.ProductApi.Dtos.ProductDtos;
using Mango.Services.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductApi.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            if(product.ProductId > 0)
            {
                _dbContext.Products.Update(product);
            }
            else
            {
                _dbContext.Products.Add(product);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                Product product = await _dbContext.Products.FirstOrDefaultAsync(c => c.ProductId == id);
                if (product == null) return false;
                else
                {
                    _dbContext.Products.Remove(product);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            IEnumerable<ProductDto> products = await _dbContext.Products.Select(c => _mapper.Map<ProductDto>(c)).ToListAsync();
            return products;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            Product product = await _dbContext.Products.Where(c => c.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
