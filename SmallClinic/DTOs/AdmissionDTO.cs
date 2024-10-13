using SmallClinic.Domain.Entities;

namespace SmallClinic.API.DTOs
{
    public class AdmissionDTO
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public Guid PatientId { get; set; }  // Khóa ngoại tới Patient
        public Patient Patient { get; set; }  // Mối quan hệ tới Patient
        public Guid DoctorId { get; set; }  // Khóa ngoại tới Doctor
        public Doctor Doctor { get; set; }  // Mối quan hệ tới Doctor
        public Guid AdmissionStatusId { get; set; }  // Khóa ngoại tới AdmissionStatus
        public AdmissionStatus AdmissionStatus { get; set; }  // Mối quan hệ tới AdmissionStatus
        public IQueryable<AdmissionLine> AdmissionLines { get; set; }  // Mối quan hệ với AdmissionLine

        public IQueryable<Invoice> Invoices { get; set; }
    }
}
