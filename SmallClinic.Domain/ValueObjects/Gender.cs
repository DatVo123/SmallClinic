using SmallClinic.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SmallClinic.Domain.ValueObjects
{
    public class Gender : EntityBase
    {
        public string GenderId { get; private set; }
        public string Name { get; private set; }
        public Gender(string id, string name) {
            GenderId = id;
            Name = name;
        }
        public Gender() { } 
    }
}
