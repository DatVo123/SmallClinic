using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using System.Linq.Expressions;

namespace SmallClinic.Application.Services
{
    public class AdmissionLineService(IUnitOfWork unitOfWork) : IService<AdmissionLine>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public void Add(AdmissionLine entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "AdmissionLine can't be null!");

            if (!_unitOfWork.Admissions.IsExisted(a => a.Id == entity.AdmissionId))
                throw new KeyNotFoundException($"Admission with ID {entity.AdmissionId} does not exist!");

            if (!_unitOfWork.Services.IsExisted(s => s.Id == entity.ServiceId))
                throw new KeyNotFoundException($"Service with ID {entity.ServiceId} does not exist!");

            if (IsExisted(a => a.AdmissionId == entity.AdmissionId && a.ServiceId == entity.ServiceId))
                throw new InvalidOperationException("This service is already added to the admission.");

            var service = _unitOfWork.Services.GetById(entity.ServiceId);

            if (entity.Quantity <= 0)
                throw new InvalidOperationException("Quantity is invalid!");
            
            entity.Amount = entity.CalculateAmount(service.Price, entity.Discount, entity.Quantity);
            

            _unitOfWork.AdmissionLines.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<AdmissionLine> Find(Expression<Func<AdmissionLine, bool>> predicate)
        {
            return _unitOfWork.AdmissionLines.Find(predicate);
        }

        public bool IsExisted(Expression<Func<AdmissionLine, bool>> predicate)
        {
            return Find(predicate).Any();
        }

        public AdmissionLine GetById(Guid id)
        {
            return _unitOfWork.AdmissionLines.GetById(id) ?? throw new KeyNotFoundException($"AdmissionLine with ID {id} not found!");
        }

        public void Remove(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Lines with id {id} not found!");
            }
            _unitOfWork.AdmissionLines.Remove(id);
            _unitOfWork.SaveChanges();
        }

        public void Update(AdmissionLine entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "AdmissionLine can't be null!");

            var existingAdmissionLine = GetById(entity.Id);
            if (existingAdmissionLine == null)
                throw new KeyNotFoundException($"AdmissionLine with ID {entity.Id} not found!");

            if (entity.Discount < 0)
                throw new InvalidOperationException("Discount is invalid!");

            if (entity.Quantity <= 0)
                throw new InvalidOperationException("Quantity is invalid!");

            _unitOfWork.AdmissionLines.Update(entity);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<AdmissionLine> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than 0.");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than 0.");

            return _unitOfWork.AdmissionLines.GetAll(pageNumber, pageSize);
        }

        public void RemovePermanently(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Lines with id {id} not found!");
            }
            _unitOfWork.AdmissionLines.RemovePermanently(id);
            _unitOfWork.SaveChanges();
        }

        public void Restore(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Lines with id {id} not found!");
            }
            _unitOfWork.AdmissionLines.Restore(id);
            _unitOfWork.SaveChanges();
        }

        public int Count()
        {
            return _unitOfWork.AdmissionLines.Count();
        }

        public IEnumerable<AdmissionLine> GetAllWithoutPaging()
        {
            throw new NotImplementedException();
        }
    }
}
