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
    public class PatientController(IService<Patient> patientService, IMapper mapper) : ControllerBase
    {
        private readonly IService<Patient> _patientService = patientService;
        private readonly IMapper _mapper = mapper;

        [HttpGet("GetAll")]
        public IActionResult GetAll(int pageNumber = 1, int pageSize = 5)
        {
            var patients = _patientService.GetAll(pageNumber, pageSize).OrderBy(s => s.Code);
            var patientDtos = _mapper.Map<IEnumerable<PatientDTO>>(patients);
            var totalRecords = _patientService.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var response = new
            {
                Data = patientDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = totalPages
            };
            return Ok(response);
        }
        [HttpGet("Get")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var patient = _patientService.GetById(id);
                var patientDto = _mapper.Map<PatientDTO>(patient);
                return Ok(patientDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
