using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallClinic.API.DTOs;
using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SmallClinic.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        private readonly IService<Admission> _admissionService;
        private readonly IService<Doctor> _doctorService;
        private readonly IService<Patient> _patientService;
        private readonly IService<AdmissionLine> _admissionLineService;
        private readonly IMapper _mapper;

        public AdmissionController(
            IService<Admission> admissionService,
            IService<Doctor> doctorService,
            IService<Patient> patientService,
            IService<AdmissionLine> admissionLineService,
            IMapper mapper)
        {
            _admissionService = admissionService;
            _doctorService = doctorService;
            _patientService = patientService;
            _admissionLineService = admissionLineService;
            _mapper = mapper;
        }

       

    }
}
