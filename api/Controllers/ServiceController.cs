using dotnet_webapi_anuncios.Dtos.Service;
using dotnet_webapi_anuncios.Helpers;
using dotnet_webapi_anuncios.Interfaces;
using dotnet_webapi_anuncios.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_anuncios.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepo;
        
        public ServiceController(IServiceRepository serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject queryParams) {
            var services = await _serviceRepo.GetAllAsync(queryParams);
            var serviceDto = services.Select(s => s.ToServiceDto()); 
            return Ok(serviceDto);
        }

        [HttpGet("{id:int}")]
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
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateServiceRequestDto updateDto) {
            var serviceModel = await _serviceRepo.UpdateAsync(id, updateDto);
            if (serviceModel == null) {
                return NotFound();
            }
            return Ok(serviceModel.ToServiceDto());
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
            var serviceModel = await _serviceRepo.DeleteAsync(id);
            if (serviceModel == null) {
                return NotFound();
            }
            return Ok(serviceModel.ToServiceDto());
        }

    }
}