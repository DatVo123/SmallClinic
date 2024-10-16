namespace SmallClinic.Domain.Entities
{
    public class AdmissionLine(Guid admissionId, Guid serviceId, string? description, decimal? discount, int quantity) : EntityBase
    {
        public Guid AdmissionId { get; private set; } = admissionId;
        public Admission? Admission { get; private set; }  // Mối quan hệ tới Admission
        public Guid ServiceId { get; private set; } = serviceId;
        public Service? Service { get; private set; }  // Mối quan hệ tới Service
        public Guid AdmissionStatusId { get; private set; } = Guid.Parse("C2C6AFD8-EF89-426B-9AC9-FB9A8E0DA881");
        public AdmissionStatus? AdmissionStatus { get; private set; }
        public string? Description { get; private set; } = description;
        public decimal? Discount { get; private set; } = discount ?? 0;
        public int Quantity { get; private set; } = quantity;
        public decimal Amount { get; set; }
        public decimal CalculateAmount(decimal price, decimal? discount, int quantity)
        {
           decimal finalDiscount = discount ?? 0;
            if (finalDiscount > 1 || finalDiscount < 0)
                throw new ArgumentOutOfRangeException(nameof(discount), "Discount must be between 0 and 1.");
                
            return (price - (price * finalDiscount)) * quantity;
        }

    }


}
