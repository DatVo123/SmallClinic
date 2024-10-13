namespace SmallClinic.Domain.Entities
{
    public class InvoiceStatus(string code, string name) : EntityBase
    {
        public string Code { get; set; } = code;
        public string Name { get; set; } = name;
    }
}
