using SmallClinic.Domain.Interfaces;

namespace SmallClinic.Domain.Entities
{
    public class Service(string code, string name, decimal price, string description) : EntityBase, IHasCode
    {
        public string Code { get; private set; } = code;
        public string Name { get; private set; } = name;

        public decimal Price { get; private set; } = price;
        public string? Description { get; private set; } = description;

    }
}
