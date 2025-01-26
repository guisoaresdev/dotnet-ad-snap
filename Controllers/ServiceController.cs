using dotnet_webapi_anuncios.Data;
using dotnet_webapi_anuncios.Dtos.Service;
using dotnet_webapi_anuncios.Mappers;
using dotnet_webapi_anuncios.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi_anuncios.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceRepository _serviceRepo;
        
        public ServiceController(ServiceRepository serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var services = await _serviceRepo.GetAllAsync();
            var serviceDto = services.Select(s => s.ToServiceDto()); 
            return Ok(serviceDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            var service = await _serviceRepo.GetByIdAsync(id);
            if (service == null) {
                return NotFound();
            }
            return Ok(service.ToServiceDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateServiceRequestDto serviceDto) {
            var serviceModel = serviceDto.ToServiceFromCreateDto();
            await _serviceRepo.CreateAsync(serviceModel);
            return CreatedAtAction(nameof(GetById), new {id = serviceModel.Id }, serviceModel.ToServiceDto());
        }
        
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateServiceRequestDto updateDto) {
            var serviceModel = await _serviceRepo.UpdateAsync(id, updateDto);
            if (serviceModel == null) {
                return NotFound();
            }
            return Ok(serviceModel.ToServiceDto());
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var serviceModel = await _serviceRepo.DeleteAsync(id);
            if (serviceModel == null) {
                return NotFound();
            }
            return Ok(serviceModel.ToServiceDto());
        }

    }
}