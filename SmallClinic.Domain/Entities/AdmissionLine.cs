namespace SmallClinic.Domain.Entities
{
    public class AdmissionLine(Guid admissionId, Guid serviceId, Guid admissionStatusId, string? description, decimal? discount, int quantity, decimal amount) : EntityBase
    {
        public Guid AdmissionId { get; private set; } = admissionId;
        public Admission Admission { get; private set; }  // Mối quan hệ tới Admission
        public Guid ServiceId { get; private set; } = serviceId;
        public Service Service { get; private set; }  // Mối quan hệ tới Service
        public Guid AdmissionStatusId { get; private set; } = admissionStatusId;
        public AdmissionStatus AdmissionStatus { get; private set; }
        public string? Description { get; private set; } = description;
        public decimal? Discount { get; private set; } = discount ?? 0;
        public int Quantity { get; private set; } = quantity;
        public decimal Amount { get; private set; } = amount;
    }


}
