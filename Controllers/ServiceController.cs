using dotnet_webapi_anuncios.Data;
using dotnet_webapi_anuncios.Dtos.Service;
using dotnet_webapi_anuncios.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_anuncios.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private ApplicationDBContext _context;
        
        public ServiceController(ApplicationDBContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetAll() {
            var service = _context.Services.Select(s => s.ToServiceDto()).ToList();
            return Ok(service);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) {
            var service = _context.Services.Find(id);
            if (service == null) {
                return NotFound();
            }
            return Ok(service.ToServiceDto());
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] CreateServiceRequestDto serviceDto) {
            var serviceModel = serviceDto.ToServiceFromCreateDto();
            _context.Services.Add(serviceModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = serviceModel.Id }, serviceModel.ToServiceDto());
        }
        
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateServiceRequestDto updateDto) {
            var serviceModel = _context.Services.FirstOrDefault(x => x.Id == id);
            if (serviceModel == null) {
                return NotFound();
            }
            //TODO: Implementar Repository
            serviceModel.Nome = updateDto.Nome;
            serviceModel.Valor = updateDto.Valor;
            serviceModel.Cidade = updateDto.Cidade;

            _context.SaveChanges();
            return Ok(serviceModel.ToServiceDto());
        }
        
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id) {
            var serviceModel = _context.Services.FirstOrDefault(x => x.Id == id);
            if (serviceModel == null) {
                return NotFound();
            }
            _context.Remove(serviceModel);
            _context.SaveChanges();
            return Ok(serviceModel.ToServiceDto());
        }

    }
}