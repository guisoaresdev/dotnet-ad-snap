using dotnet_webapi_anuncios.Data;
using dotnet_webapi_anuncios.Dtos;
using dotnet_webapi_anuncios.Dtos.Product;
using dotnet_webapi_anuncios.Interfaces;
using dotnet_webapi_anuncios.Mappers;
using dotnet_webapi_anuncios.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi_anuncios.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext applicationDbContext) 
        {
            _context = applicationDbContext;
        }
        
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null) {
                return null;
            }
            _context.Remove(id);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> UpdateAsync(int id, UpdateProductRequestDto productDto)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null) {
                throw new ArgumentException("Product not found");
            }
            productModel.Nome = productDto.Nome;
            productModel.Valor = productDto.Valor;
            productModel.Cidade = productDto.Cidade;
            productModel.Categoria = productDto.Categoria;
            productModel.Modelo = productDto.Modelo;
            productModel.Condicao = productDto.Condicao;
            productModel.Quantidade = productDto.Quantidade;

            await _context.SaveChangesAsync();
            return productModel;
        }

    }
}