using dotnet_webapi_anuncios.Dtos.Service;
using dotnet_webapi_anuncios.Models;

namespace dotnet_webapi_anuncios.Interfaces
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAllAsync();
        
        Task<Service?> GetByIdAsync(int id);
        
        Task<Service> CreateAsync(Service serviceModel);
        
        Task<Service?> UpdateAsync(int id, UpdateServiceRequestDto serviceDto);
        
        Task<Service?> DeleteAsync(int id);
    }
}