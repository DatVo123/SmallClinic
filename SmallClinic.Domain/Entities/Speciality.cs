using SmallClinic.Domain.Interfaces;

namespace SmallClinic.Domain.Entities
{
    public class Speciality(string code, string name) : EntityBase, IHasCode
    {
        public string Code { get; private set; } = code;
        public string Name { get; private set; } = name;

    }

}
