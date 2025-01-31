using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_anuncios.Data;
using dotnet_webapi_anuncios.Dtos.Service;
using dotnet_webapi_anuncios.Helpers;
using dotnet_webapi_anuncios.Interfaces;
using dotnet_webapi_anuncios.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi_anuncios.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDBContext _context;

        public ServiceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Service> CreateAsync(Service serviceModel)
        {
            await _context.Services.AddAsync(serviceModel);
            await _context.SaveChangesAsync();
            return serviceModel;
        }

        public async Task<Service?> DeleteAsync(int id)
        {
            var serviceModel = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (serviceModel == null) {
                return null;
            }
            _context.Remove(id);
            await _context.SaveChangesAsync();
            return serviceModel;
        }

        public async Task<List<Service>> GetAllAsync(QueryObject queryParams)
        {
            var services = _context.Services.AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryParams.Valor)) {
                services = services.Where(s => s.Valor.Equals(queryParams.Valor));
            }
            if (!string.IsNullOrWhiteSpace(queryParams.Cidade)) {
                services = services.Where(s => s.Cidade.Contains(queryParams.Cidade));
            }
            if (!string.IsNullOrWhiteSpace(queryParams.SortBy)) {
                if (queryParams.SortBy.Equals("Valor", StringComparison.OrdinalIgnoreCase)) {
                    services = queryParams.IsDescending ? services.OrderByDescending(p => p.Valor) : services.OrderBy(p => p.Valor);
                }
                if (queryParams.SortBy.Equals("Cidade", StringComparison.OrdinalIgnoreCase)) {
                    services = queryParams.IsDescending ? services.OrderByDescending(p => p.Cidade) : services.OrderBy(p => p.Cidade);
                }

            }
            var skipNumber = (queryParams.PageNumber - 1) * queryParams.PageSize;
            return await services.Skip(skipNumber).Take(queryParams.PageSize).ToListAsync();
        }

        public async Task<Service?> GetByIdAsync(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Service?> UpdateAsync(int id, UpdateServiceRequestDto serviceDto)
        {
            var serviceModel = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (serviceModel == null) {
                throw new ArgumentException("service not found");
            }
            serviceModel.Nome = serviceDto.Nome;
            serviceModel.DataPublicacao = serviceDto.DataPublicacao;
            serviceModel.Valor = serviceDto.Valor;
            serviceModel.Cidade = serviceDto.Cidade;

            await _context.SaveChangesAsync();
            return serviceModel;
        }
    }
}