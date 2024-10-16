using SmallClinic.Domain.Entities;

namespace SmallClinic.API.DTOs
{
    public class AdmissionLineDTO
    {
        public Guid AdmissionId { get; set; }  // Khóa ngoại tới Admission
        public Guid ServiceId { get; set; }  // Khóa ngoại tới Service
        public string? Description { get; set; }
        public decimal? Discount { get; set; } = 0;
        public int Quantity { get; set; } = 1;
    }
}
