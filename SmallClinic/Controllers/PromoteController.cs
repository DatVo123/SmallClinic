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
    public class PromoteController(IService<Promote> promoteService, IMapper mapper) : ControllerBase
    {
        IService<Promote> _promoteService = promoteService;
        IMapper _mapper = mapper;

        [HttpPost("Create")]
        public IActionResult Create([FromBody] PromoteDTO PromoteDTO)
        {
            if (PromoteDTO == null)
                return BadRequest("Promote can't be null!");
            try
            {
                var Promote = _mapper.Map<Promote>(PromoteDTO);
                _promoteService.Add(Promote);
                return CreatedAtAction(nameof(GetById), new { id = Promote.Id }, PromoteDTO);
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
                var promote = _promoteService.GetById(id);
                var promoteDTO = _mapper.Map<PromoteDTO>(promote);
                return Ok(promoteDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll(int pageNumber = 1, int pageSize = 5)
        {
            var promotes = _promoteService.GetAll(pageNumber, pageSize).OrderBy(s => s.Code);
            var promotesDTO = _mapper.Map<IEnumerable<PromoteDTO>>(promotes);
            var totalRecords = _promoteService.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var response = new
            {
                Data = promotesDTO,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = totalPages
            };
            return Ok(response);
        }
        [HttpPut("Update")]
        public IActionResult Update(Guid id, PromoteDTO promoteDTO)
        {
            var existedPromote = _promoteService.GetById(id);
            _mapper.Map(promoteDTO, existedPromote);
            try
            {
                _promoteService.Update(existedPromote);
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
                _promoteService.Remove(id);
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
                _promoteService.Restore(id);
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
                _promoteService.RemovePermanently(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
