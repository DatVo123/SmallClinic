using SmallClinic.Domain.Interfaces;
using SmallClinic.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace SmallClinic.Domain.Entities
{
    public class Patient(string name, DateTime dateOfBirth, Guid genderId) : EntityBase, IHasCode
    {
        public string Code { get; set; }
        public string Name { get; private set; } = name;
        public DateTime DateOfBirth { get; private set; } = dateOfBirth;
        public Guid GenderId { get; private set; } = genderId;
        public Gender Gender { get; private set; }

        [JsonIgnore]
        public IQueryable<Admission>? Admissions { get; private set; }
    }
}
