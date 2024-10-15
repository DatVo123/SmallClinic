using SmallClinic.Domain.Entities;
using System.Linq.Expressions;

namespace SmallClinic.Infrastructure.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll(int pageNumber, int pageSize);
        IEnumerable<T> GetAllWithoutPaging();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        public bool IsExisted(Expression<Func<T, bool>> predicate);
        void Remove(Guid id);
        void RemovePermanently(Guid id);
        void Restore(Guid id);
        void Update(T entity);
        int Count();
    }
}
