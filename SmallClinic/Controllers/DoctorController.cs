﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallClinic.API.DTOs;
using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;

namespace SmallClinic.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController(IService<Doctor> doctorService, IMapper mapper) : ControllerBase
    {
        private readonly IService<Doctor> _doctorService = doctorService;
        private readonly IMapper _mapper = mapper;

        [HttpGet("GetAll")]
        public IActionResult GetAll(int pageNumber = 1, int pageSize = 5)
        {
            var doctors = _doctorService.GetAll(pageNumber, pageSize).OrderBy(s => s.Code);
            var doctorDtos = _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
            var totalRecords = _doctorService.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var response = new
            {
                Data = doctorDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = totalPages
            };
            return Ok(response);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] DoctorDTO doctorDTO)
        {
            if (doctorDTO == null)
                return BadRequest("Doctor can't be null!");
            try
            {
                var doctor = _mapper.Map<Doctor>(doctorDTO);
                _doctorService.Add(doctor);
                return CreatedAtAction(nameof(Get), new { id = doctor.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var doctor = _doctorService.GetById(id);
                var doctorDto = _mapper.Map<DoctorDTO>(doctor);
                return Ok(doctorDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
