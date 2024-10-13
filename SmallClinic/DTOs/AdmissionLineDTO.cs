using SmallClinic.Domain.Entities;

namespace SmallClinic.API.DTOs
{
    public class AdmissionLineDTO
    {
        public Guid AdmissionId { get; set; }  // Khóa ngoại tới Admission
        public Guid ServiceId { get; set; }  // Khóa ngoại tới Service
        public Service Service { get; set; }  // Mối quan hệ tới Service
        public Guid AdmissionStatusId { get; set; }
        public string? Description { get; set; }
        public decimal? Discount { get; set; } = 0;
        public int Quantity { get; set; } = 1;
        public decimal Amount { get; set; }
    }
}
