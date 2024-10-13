using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallClinic.API.DTOs;
using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;

namespace SmallClinic.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController(IService<Service> serviceService, IMapper mapper) : ControllerBase
    {
        private readonly IService<Service> _serviceService = serviceService;
        private readonly IMapper _mapper = mapper;

        [HttpGet("GetAll")]
        public IActionResult GetAll(int pageNumber = 1, int pageSize = 5)
        {
            var services = _serviceService.GetAll(pageNumber, pageSize).OrderBy(s=> s.Code);
            var serviceDtos = _mapper.Map<IEnumerable<ServiceDTO>>(services);
            var totalRecords = _serviceService.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var response = new
            {
                Data = serviceDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = totalPages
            };
            return Ok(response);
        }

        [HttpGet("Get")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var service = _serviceService.GetById(id);
                var serviceDto = _mapper.Map<ServiceDTO>(service);
                return Ok(serviceDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] ServiceDTO serviceDto)
        {
            if (serviceDto == null)
            {
                return BadRequest("Service cannot be null.");
            }
            
            try
            {
                var service = _mapper.Map<Service>(serviceDto);
                _serviceService.Add(service);
                return CreatedAtAction(nameof(GetById), new { id = service.Id }, serviceDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(Guid id, [FromBody] ServiceDTO serviceDto)
        {
            if (serviceDto == null)
            {
                return BadRequest("Service cannot be null and IDs must match.");
            }
            var existedService = _serviceService.GetById(id);
            _mapper.Map(serviceDto, existedService);

            try
            {
                _serviceService.Update(existedService);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Restore")]
        public IActionResult Restore(Guid id)
        {
            try
            {
                _serviceService.Restore(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Remove")]
        public IActionResult Remove(Guid id)
        {
            try
            {
                _serviceService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("RemovePermanently")]
        public IActionResult RemovePermanently(Guid id)
        {
            try
            {
                _serviceService.RemovePermanently(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
