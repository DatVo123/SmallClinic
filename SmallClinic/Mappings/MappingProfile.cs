using AutoMapper;
using SmallClinic.API.DTOs;
using SmallClinic.Domain.Entities;

namespace SmallClinic.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Service, ServiceDTO>().ReverseMap(); 
            CreateMap<Speciality, SpecialityDTO>().ReverseMap();
            CreateMap<Promote, PromoteDTO>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();  
            CreateMap<Doctor, DoctorDTO>().ReverseMap();  
            CreateMap<AdmissionLine,AdmissionLineDTO>().ReverseMap();
            CreateMap<Admission,AdmissionDTO>().ReverseMap();

        }
    }
}
