using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_anuncios.Dtos.Product;
using dotnet_webapi_anuncios.Helpers;
using dotnet_webapi_anuncios.Models;

namespace dotnet_webapi_anuncios.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(QueryObject queryParams);
        
        Task<Product?> GetByIdAsync(int id);
        
        Task<Product> CreateAsync(Product productModel);
        
        Task<Product?> UpdateAsync(int id, UpdateProductRequestDto productDto);
        
        Task<Product?> DeleteAsync(int id);
    }
}