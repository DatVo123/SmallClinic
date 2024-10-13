using SmallClinic.Domain.Interfaces;

namespace SmallClinic.Domain.Entities
{
    public class InvoiceLine(Guid invoiceId, Guid serviceId, Guid invoiceStatusId, string? description, decimal? discount, int quantity, decimal amount) : EntityBase
    {
        public Guid InvoiceId { get; private set; } = invoiceId;
        public Invoice Invoice { get; private set; }
        public Guid ServiceId { get; private set; } = serviceId;
        public Service Service { get; private set; }
        public Guid InvoiceStatusId { get; private set; } = invoiceStatusId;
        public InvoiceStatus InvoiceStatus { get; private set; }
        public string? Description { get; private set; } = description;
        public decimal? Discount { get; private set; } = discount ?? 0;
        public int Quantity { get; private set; } = quantity;
        public decimal Amount { get; private set; } = amount;
    }
}
