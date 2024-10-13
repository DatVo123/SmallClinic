using SmallClinic.Domain.Entities;

namespace SmallClinic.API.DTOs
{
    public class InvoiceLineDTO
    {
        public Guid InvoiceId { get; private set; }  // Khóa ngoại tới Invoice
        public Guid ServiceId { get; private set; }  // Khóa ngoại tới Service
        public Guid InvoiceStatusId { get; private set; }
        public InvoiceStatus InvoiceStatus { get; private set; }
        public string? Description { get; private set; }
        public decimal? Discount { get; private set; }
        public int Quantity { get; private set; } = 1;
        public decimal Amount { get; private set; }
    }
}
