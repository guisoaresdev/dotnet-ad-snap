using dotnet_webapi_anuncios.Data;
using dotnet_webapi_anuncios.Dtos.Product;
using dotnet_webapi_anuncios.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_anuncios.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ApplicationDBContext _context;

        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var products = _context.Products.Select(s => s.ToProductDto()).ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) {
            var product = _context.Products.Find(id);
            if (product == null) {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] CreateProductRequestDto productDto) {
            var productModel = productDto.ToProductFromCreateDto();
            _context.Products.Add(productModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = productModel.Id }, productModel.ToProductDto());
        }
        
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateProductRequestDto updateDto) {
            var productModel = _context.Products.FirstOrDefault(x => x.Id == id);
            if (productModel == null) {
                return NotFound();
            }
            //TODO: Implementar Repository
            productModel.Nome = updateDto.Nome;
            productModel.Valor = updateDto.Valor;
            productModel.Cidade = updateDto.Cidade;
            productModel.Categoria = updateDto.Categoria;
            productModel.Modelo = updateDto.Modelo;
            productModel.Condicao = updateDto.Condicao;
            productModel.Quantidade = updateDto.Quantidade;

            _context.SaveChanges();
            return Ok(productModel.ToProductDto());
        }
        
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id) {
            var productModel = _context.Products.FirstOrDefault(x => x.Id == id);
            if (productModel == null) {
                return NotFound();
            }
            _context.Remove(productModel);
            _context.SaveChanges();
            return Ok(productModel.ToProductDto());
        }
    }
}