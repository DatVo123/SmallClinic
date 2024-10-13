using SmallClinic.Domain.Entities;
using SmallClinic.Infrastructure.Repositories;

namespace SmallClinic.Domain.Interfaces
{
    public interface IService<T> : IRepository<T> where T : EntityBase
    {
    }
}
