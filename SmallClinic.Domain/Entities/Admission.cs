using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;

public class Admission(Guid patientId, Guid doctorId) : EntityBase, IHasCode
{
    public string Code { get; set; }
    public DateTime Date { get; private set; } = DateTime.Now;
    public Guid PatientId { get; set; } = patientId;
    public Patient? Patient { get; set; }  // Mối quan hệ tới Patient
    public Guid DoctorId { get; set; } = doctorId;
    public Doctor? Doctor { get; set; }  // Mối quan hệ tới Doctor
    public Guid AdmissionStatusId { get; set; } = Guid.Parse("C2C6AFD8-EF89-426B-9AC9-FB9A8E0DA881");
    public AdmissionStatus? AdmissionStatus { get; set; }  // Mối quan hệ tới AdmissionStatus
    public IQueryable<AdmissionLine>? AdmissionLines { get; set; }  // Mối quan hệ với AdmissionLine
    public IQueryable<Invoice>? Invoices { get; set; }  // Mối quan hệ với Invoice
}
