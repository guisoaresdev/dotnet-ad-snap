using dotnet_webapi_anuncios.Data;
using dotnet_webapi_anuncios.Dtos.Product;
using dotnet_webapi_anuncios.Helpers;
using dotnet_webapi_anuncios.Interfaces;
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
        
        public async Task<List<Product>> GetAllAsync(QueryObject queryParams)
        {
            var products = _context.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryParams.Valor)) {
                products = products.Where(s => s.Valor.Equals(queryParams.Valor));
            }
            if (!string.IsNullOrWhiteSpace(queryParams.Cidade)) {
                products = products.Where(s => s.Cidade.Contains(queryParams.Cidade));
            }
            if (!string.IsNullOrWhiteSpace(queryParams.SortBy)) {
                if (queryParams.SortBy.Equals("Valor", StringComparison.OrdinalIgnoreCase)) {
                    products = queryParams.IsDescending ? products.OrderByDescending(p => p.Valor) : products.OrderBy(p => p.Valor);
                }
                if (queryParams.SortBy.Equals("Cidade", StringComparison.OrdinalIgnoreCase)) {
                    products = queryParams.IsDescending ? products.OrderByDescending(p => p.Cidade) : products.OrderBy(p => p.Cidade);
                }
                if (queryParams.SortBy.Equals("Categoria", StringComparison.OrdinalIgnoreCase)) {
                    products = queryParams.IsDescending ? products.OrderByDescending(p => p.Categoria) : products.OrderBy(p => p.Categoria);
                }
                if (queryParams.SortBy.Equals("Condicao", StringComparison.OrdinalIgnoreCase)) {
                    products = queryParams.IsDescending ? products.OrderByDescending(p => p.Condicao) : products.OrderBy(p => p.Condicao);
                }
            }
            var skipNumber = (queryParams.PageNumber - 1) * queryParams.PageSize;
            return await products.Skip(skipNumber).Take(queryParams.PageSize).ToListAsync();
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
            productModel.DataPublicacao = productDto.DataPublicacao;
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