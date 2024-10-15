    using SmallClinic.Domain.Entities;

    namespace SmallClinic.API.DTOs
    {
        public class AdmissionDTO
        {
            public string PatientName { get; set; }
            public Guid GenderId { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Guid PatientId { get; set; }
            public Guid DoctorId { get; set; }

        }
    }
