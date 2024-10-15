using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallClinic.API.DTOs;
using SmallClinic.Application.Interfaces;
using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using SmallClinic.Infrastructure.Repositories;

namespace SmallClinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        private readonly IService<Admission> _admissionService;
        private readonly IService<Doctor> _doctorService;
        private readonly IPatientService _patientService;
        private readonly IService<AdmissionLine> _admissionLineService;
        private readonly IMapper _mapper;

        public AdmissionController(
            IService<Admission> admissionService,
            IService<Doctor> doctorService,
            IPatientService patientService,
            IService<AdmissionLine> admissionLineService,
            IMapper mapper)
        {
            _admissionService = admissionService;
            _doctorService = doctorService;
            _patientService = patientService;
            _admissionLineService = admissionLineService;
            _mapper = mapper;
        }
        [HttpPost("Create")]
        public IActionResult AddAdmission([FromBody] AdmissionDTO admissionDTO)
        {
            if (admissionDTO == null)
            {
                return BadRequest("Admission is null.");
            }
            try
            {
                var existingPatient = _patientService.Find(p => p.Name == admissionDTO.PatientName
                                           && p.DateOfBirth == admissionDTO.DateOfBirth).FirstOrDefault();

                if (existingPatient == null)
                {
                    var patient = new Patient(admissionDTO.PatientName, admissionDTO.DateOfBirth, admissionDTO.GenderId);
                    _patientService.Add(patient);
                    admissionDTO.PatientId = patient.Id;
                }
                else
                {
                    admissionDTO.PatientId = existingPatient.Id;
                }

                var admission = new Admission(patientId: admissionDTO.PatientId, doctorId: admissionDTO.DoctorId);
                _admissionService.Add(admission);

                return CreatedAtAction(nameof(GetAdmissionById), new { id = admission.Id }, admission);
            }
            catch (ArgumentNullException argEx)
            {
                return BadRequest(argEx.Message);
            }
            catch (InvalidOperationException invEx)
            {
                return Conflict(invEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("Get")]
        public IActionResult GetAdmissionById(Guid id)
        {
            var admission = _admissionService.GetById(id);
            if (admission == null)
            {
                return NotFound();
            }
            return Ok(admission);
        }
    }
}
