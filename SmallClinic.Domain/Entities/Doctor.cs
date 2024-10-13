using SmallClinic.Domain.Interfaces;
using SmallClinic.Domain.ValueObjects;

namespace SmallClinic.Domain.Entities
{
    public class Doctor(string code, string name, Guid genderId, Guid specialityId) : EntityBase, IHasCode
    {
        public string Code { get; private set; } = code;
        public string Name { get; private set; } = name;
        public Guid GenderId { get; private set; } = genderId;
        public Gender Gender { get; private set; } 
        public Guid SpecialityId { get; private set; } = specialityId;
        public Speciality Speciality { get; private set; } 
        public IQueryable<Admission> Admissions { get; private set; }
    }

}
