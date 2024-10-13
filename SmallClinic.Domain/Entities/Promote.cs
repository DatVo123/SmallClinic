using SmallClinic.Domain.Interfaces;

namespace SmallClinic.Domain.Entities
{
    public class Promote(string code, string name, string? description, DateTime startDate, DateTime endDate, decimal discount) : EntityBase, IHasCode
    {
        public string Code { get; set; } = code;
        public string Name { get; set; } = name;
        public string? Description { get; set; } = description;
        public DateTime StartDate { get; set; } = startDate;
        public DateTime EndDate { get; set; } = endDate;
        public decimal Discount { get; set; } = discount;

    }
}
