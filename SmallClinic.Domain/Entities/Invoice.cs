using SmallClinic.Domain.Interfaces;

namespace SmallClinic.Domain.Entities
{
    public class Invoice(DateTime date, decimal amount, decimal? discount, decimal netAmount, Guid patientId, Guid invoiceStatusId, Guid? prommoteId, Guid admissionId) : EntityBase, IHasCode
    {
        public string Code { get; private set; }
        public DateTime Date { get; private set; } = date;
        public decimal Amount { get; private set; } = amount;
        public decimal? Discount { get; private set; } = discount;
        public decimal NetAmount { get; private set; } = netAmount;
        public Guid PatientId { get; private set; } = patientId;
        public Patient Patient { get; private set; }
        public Guid InvoiceStatusId { get; private set; } = invoiceStatusId;
        public InvoiceStatus InvoiceStatus { get; private set; }
        public Guid? PrommoteId { get; private set; } = prommoteId;
        public Promote Promote { get; private set; }
        public Guid AdmissionId { get; private set; } = admissionId;
        public Admission Admission { get; private set; }
        public IQueryable<InvoiceLine> InvoiceLines { get; private set; }
    }
}
