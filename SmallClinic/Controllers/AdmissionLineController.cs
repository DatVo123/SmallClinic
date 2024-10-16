using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallClinic.API.DTOs;
using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;

namespace SmallClinic.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionLineController : ControllerBase
    {
        private readonly IService<AdmissionLine> _admissionLine;
        private readonly IMapper _mapper;

        public AdmissionLineController(IService<AdmissionLine> admissionLineService, IMapper mapper)
        {
            _admissionLine = admissionLineService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var admissionLines = _admissionLine.GetAllWithoutPaging();
            var admissionLineDtos = _mapper.Map<IEnumerable<AdmissionLineDTO>>(admissionLines);
            return Ok(admissionLineDtos);
        }

        [HttpGet("Get")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var admissionLine = _admissionLine.GetById(id);
                var admissionLineDTO = _mapper.Map<AdmissionLineDTO>(admissionLine);
                return Ok(admissionLineDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create(AdmissionLineDTO admissionLineDTO)
        {
            try
            {
                var admissionLine = _mapper.Map<AdmissionLine>(admissionLineDTO);
                _admissionLine.Add(admissionLine);

                return Ok(new { Message = "AdmissionLine created successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(Guid id, AdmissionLineDTO admissionLineDTO)
        {
            try
            {
                var existingAdmissionLine = _admissionLine.GetById(id);

                _mapper.Map(admissionLineDTO, existingAdmissionLine);
                _admissionLine.Update(existingAdmissionLine);

                return Ok(new { Message = "AdmissionLine updated successfully!" });
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
                _admissionLine.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
