using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallClinic.API.DTOs;
using SmallClinic.Application.Services;
using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;

namespace SmallClinic.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController(IService<Speciality> specialityService, IMapper mapper) : ControllerBase
    {
        IService<Speciality> _specialityService = specialityService;
        IMapper _mapper = mapper;

        [HttpPost("Create")]
        public IActionResult Create([FromBody] SpecialityDTO specialityDTO) {
            if (specialityDTO == null)
                return BadRequest("Speciality can't be null!");
            try
            {
                var speciality = _mapper.Map<Speciality>(specialityDTO);
                _specialityService.Add(speciality);
                return CreatedAtAction(nameof(GetById), new { id = speciality.Id }, specialityDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
        [HttpGet("Get")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var speciality = _specialityService.GetById(id);
                var specialityDTO = _mapper.Map<SpecialityDTO>(speciality);
                return Ok(specialityDTO);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll(int pageNumber = 1, int pageSize = 5)
        {
            var specialities = _specialityService.GetAll(pageNumber, pageSize).OrderBy(s => s.Code);
            var specialitiesDTO = _mapper.Map<IEnumerable<SpecialityDTO>>(specialities);
            var totalRecords = _specialityService.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var response = new
            {
                Data = specialitiesDTO,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = totalPages
            };
            return Ok(response);
        }
        [HttpPut("Update")]
        public IActionResult Update(Guid id, SpecialityDTO specialityDTO)
        {
            if (specialityDTO == null)
            {
                return BadRequest("Service cannot be null and IDs must match.");
            }
            var existedSpeciality = _specialityService.GetById(id);
            _mapper.Map(specialityDTO, existedSpeciality);
            try
            {
                _specialityService.Update(existedSpeciality);
                return NoContent();
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
                _specialityService.Remove(id);
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
                _specialityService.Restore(id);
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
                _specialityService.RemovePermanently(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
