using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;

namespace SmallClinic.Application.Interfaces
{
    public interface IPatientService : IService<Patient>
    {
        public string GeneratePatientCode();
    }
}
