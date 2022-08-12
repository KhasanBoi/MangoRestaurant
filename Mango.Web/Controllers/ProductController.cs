using AutoMapper;
using Mango.Web.Dtos;
using Mango.Web.Dtos.ProductDto;
using Mango.Web.Services.IServices.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new();
            var response = await _productService.GetAllProductsAsync<ResponseDto>();
            if(response != null && response.Success)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Data));
            }
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync<ResponseDto>(productDto);
                if (response != null && response.Success)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(productDto);
        }


        [HttpGet]
        public async Task<IActionResult> ProductDelete(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var response = await _productService.GetProductByIdAsync<ResponseDto>(id);
            if (response != null && response.Success)
            {
                var productDto = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Data));
                return View(productDto.First());
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto productDto)
        {
            var response = await _productService.DeleteProductAsync<ResponseDto>(productDto.ProductId);
            if (response.Success)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
            return View(productDto);
        }


        [HttpGet]
        public async Task<IActionResult> ProductEdit(int? id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var response = await _productService.GetProductByIdAsync<ResponseDto>(id);
            if(response != null && response.Success)
            {
                var productDto = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Data));
                return View(productDto.First());
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto productDto)
        {
            var response = await _productService.UpdateProductAsync<ResponseDto>(productDto);
            if (response != null && response.Success)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
            return View(productDto);
        }
    }
}
