using dotnet_webapi_anuncios.Data;
using dotnet_webapi_anuncios.Dtos.Product;
using dotnet_webapi_anuncios.Interfaces;
using dotnet_webapi_anuncios.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi_anuncios.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var products = await _productRepo.GetAllAsync();
            var productDto = products.Select(s => s.ToProductDto());
            return Ok(productDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestDto productDto) {
            var productModel = productDto.ToProductFromCreateDto();
            await _productRepo.CreateAsync(productModel);
            return CreatedAtAction(nameof(GetById), new {id = productModel.Id }, productModel.ToProductDto());
        }
        
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequestDto updateDto) {
            var productModel = await _productRepo.UpdateAsync(id, updateDto);
            if (productModel == null) {
                return NotFound();
            }
            return Ok(productModel.ToProductDto());
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var productModel = await _productRepo.DeleteAsync(id);
            if (productModel == null) {
                return NotFound();
            }
            return Ok(productModel.ToProductDto());
        }
    }
}