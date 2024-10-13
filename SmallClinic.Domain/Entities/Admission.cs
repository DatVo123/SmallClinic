using SmallClinic.Domain.Interfaces;

namespace SmallClinic.Domain.Entities
{
    public class Admission(string code, DateTime date, Guid patientId, Guid doctorId, Guid admissionStatusId) : EntityBase, IHasCode
    {
        public string Code { get; private set; } = code;
        public DateTime Date { get; private set; } = date;
        public Guid PatientId { get; private set; } = patientId;
        public Patient Patient { get; private set; }  // Mối quan hệ tới Patient
        public Guid DoctorId { get; private set; } = doctorId;
        public Doctor Doctor { get; private set; }  // Mối quan hệ tới Doctor
        public Guid AdmissionStatusId { get; private set; } = admissionStatusId;
        public AdmissionStatus AdmissionStatus { get; private set; }  // Mối quan hệ tới AdmissionStatus
        public IQueryable<AdmissionLine> AdmissionLines { get; private set; }  // Mối quan hệ với AdmissionLine

        public IQueryable<Invoice> Invoices { get; private set; }
    }

}
