using SmallClinic.Domain.Entities;

namespace SmallClinic.API.DTOs
{
    public class InvoiceDTO
    {
        public string Code { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public decimal? Discount { get; private set; }
        public decimal NetAmount { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid InvoiceStatusId { get; private set; }
        public Guid? PrommoteId { get; private set; }
        public Promote Promote { get; private set; }
        public Guid AdmissionId { get; private set; }
        public IQueryable<InvoiceLine> InvoiceLines { get; private set; }
    }
}
