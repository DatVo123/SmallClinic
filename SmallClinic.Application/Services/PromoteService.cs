using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using System.Linq.Expressions;

namespace SmallClinic.Application.Promotes
{
    public class PromoteService(IUnitOfWork unitOfWork) : IService<Promote>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public void Add(Promote entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Promote can't be null!");

            if (IsExisted(s => s.Code == entity.Code))
                throw new InvalidOperationException($"Promote with code {entity.Code} already exists!");

            _unitOfWork.Promotes.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Promote> Find(Expression<Func<Promote, bool>> predicate)
        {
            return _unitOfWork.Promotes.Find(predicate);
        }

        public bool IsExisted(Expression<Func<Promote, bool>> predicate)
        {
            return _unitOfWork.Promotes.IsExisted(predicate);
        }
        public IEnumerable<Promote> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than 0.");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than 0.");

            return _unitOfWork.Promotes.GetAll(pageNumber, pageSize);
        }

        public Promote GetById(Guid id)
        {
            return _unitOfWork.Promotes.GetById(id) ?? throw new KeyNotFoundException($"Promote with id {id} is not found!");
        }

        public void Update(Promote entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Promote can't be null");

            var existingPromote = GetById(entity.Id);

            if (existingPromote.Code != entity.Code && IsExisted(s => s.Code == entity.Code))
            {
                throw new InvalidOperationException($"Promote with code {entity.Code} already exists!");
            }
            _unitOfWork.Promotes.Update(entity);
            _unitOfWork.SaveChanges();
        }
        public void Remove(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Promote with id {id} not found!");
            }
            _unitOfWork.Promotes.Remove(id);
            _unitOfWork.SaveChanges();
        }

        public void RemovePermanently(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Promote with id {id} not found!");
            }

            _unitOfWork.Promotes.RemovePermanently(id);
            _unitOfWork.SaveChanges();
        }

        public void Restore(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Promote with id {id} not found!");
            }

            _unitOfWork.Promotes.Restore(id);
            _unitOfWork.SaveChanges();
        }
        public int Count()
        {
            return _unitOfWork.Promotes.Count();
        }

    }
}
