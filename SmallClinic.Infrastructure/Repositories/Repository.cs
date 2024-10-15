using Microsoft.EntityFrameworkCore;
using SmallClinic.Domain.Entities;
using SmallClinic.Infrastructure.Data;
using System.Linq.Expressions;

namespace SmallClinic.Infrastructure.Repositories
{
    public class Repository<T>(ApplicationDBContext context) : IRepository<T> where T : EntityBase
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
        public IEnumerable<T> GetAll(int pageNumber, int pageSize)
        {
            return _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).Where(e=>e.IsDeleted==false).ToList();
        }
        public IEnumerable<T> GetAllWithoutPaging()
        {
            return _dbSet.Where(e => e.IsDeleted == false).ToList();
        }

        public T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public bool IsExisted(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public void Remove(Guid id)
        {
            var entity = GetById(id);
            entity.Remove();
            Update(entity);
        }
        public void Restore(Guid id)
        {
            var entity = GetById(id);
            entity.Restore();
            Update(entity);
        }
        public void RemovePermanently(Guid id)
        {
            var entity = GetById(id);
            _dbSet.Remove(entity);
        }
        public int Count()
        {
            return _dbSet.Count();
        }


    }
}
