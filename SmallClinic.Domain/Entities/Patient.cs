using SmallClinic.Domain.Interfaces;
using SmallClinic.Domain.ValueObjects;

namespace SmallClinic.Domain.Entities
{
    public class Patient(string code, string name, DateTime dateOfBirth, Guid genderId) : EntityBase, IHasCode
    {
        public string Code { get; private set; } = code;
        public string Name { get; private set; } = name;
        public DateTime DateOfBirth { get; private set; } = dateOfBirth;
        public Guid GenderId { get; private set; } = genderId;
        public Gender Gender { get; private set; }

        public IQueryable<Admission> Admissions { get; private set; }
    }

}
