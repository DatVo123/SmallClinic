using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using System.Linq.Expressions;

namespace SmallClinic.Application.Services
{
    public class ServiceService(IUnitOfWork unitOfWork) : IService<Service>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public void Add(Service entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Service can't be null!");

            if (IsExisted(s => s.Code == entity.Code))
                throw new InvalidOperationException($"Service with code {entity.Code} already exists!");

            if (entity.Price<0)
                throw new ArgumentException("Invalid price format");

            _unitOfWork.Services.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Service> Find(Expression<Func<Service, bool>> predicate)
        {
            return _unitOfWork.Services.Find(predicate);
        }

        public bool IsExisted(Expression<Func<Service, bool>> predicate)
        {
            return _unitOfWork.Services.IsExisted(predicate);
        }
        public IEnumerable<Service> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than 0.");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than 0.");

            return _unitOfWork.Services.GetAll(pageNumber, pageSize);
        }

        public Service GetById(Guid id)
        {
            return _unitOfWork.Services.GetById(id) ?? throw new KeyNotFoundException($"Service with id {id} is not found!");
        }

        public void Update(Service entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Service can't be null");

            var existingService = GetById(entity.Id);

            if (existingService.Code != entity.Code && IsExisted(s => s.Code == entity.Code))
            {
                throw new InvalidOperationException($"Service with code {entity.Code} already exists!");
            }
            if (entity.Price < 0)
                throw new ArgumentException("Invalid price format");
            _unitOfWork.Services.Update(entity);
            _unitOfWork.SaveChanges();
        }
        public void Remove(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Service with id {id} not found!");
            }

            _unitOfWork.Services.Remove(id);
            _unitOfWork.SaveChanges();
        }

        public void RemovePermanently(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Service with id {id} not found!");
            }

            _unitOfWork.Services.RemovePermanently(id);
            _unitOfWork.SaveChanges();
        }

        public void Restore(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Service with id {id} not found!");
            }

            _unitOfWork.Services.Restore(id);
            _unitOfWork.SaveChanges();
        }
        public int Count()
        {
            return _unitOfWork.Services.Count();
        }
    }
}
