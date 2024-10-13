using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using System.Linq.Expressions;

namespace SmallClinic.Application.Services
{
    public class InvoiceLineService(IUnitOfWork unitOfWork) : IService<InvoiceLine>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public void Add(InvoiceLine entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "InvoiceLine can't be null!");

            if (!_unitOfWork.Invoices.IsExisted(a => a.Id == entity.InvoiceId))
                throw new KeyNotFoundException($"Admission with ID {entity.InvoiceId} does not exist!");

            if (!_unitOfWork.Services.IsExisted(s => s.Id == entity.ServiceId))
                throw new KeyNotFoundException($"Service with ID {entity.ServiceId} does not exist!");

            if (IsExisted(a => a.InvoiceId == entity.InvoiceId && a.ServiceId == entity.ServiceId))
                throw new InvalidOperationException("This service is already added to the admission.");

            if (entity.Discount < 0)
                throw new InvalidOperationException("Discount is invalid!");
            if (entity.Quantity <= 0)
                throw new InvalidOperationException("Quantity is invalid!");

            _unitOfWork.InvoiceLines.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<InvoiceLine> Find(Expression<Func<InvoiceLine, bool>> predicate)
        {
            return _unitOfWork.InvoiceLines.Find(predicate);
        }

        public bool IsExisted(Expression<Func<InvoiceLine, bool>> predicate)
        {
            return Find(predicate).Any();
        }

        public InvoiceLine GetById(Guid id)
        {
            return _unitOfWork.InvoiceLines.GetById(id) ?? throw new KeyNotFoundException($"InvoiceLine with ID {id} not found!");
        }

        public void Remove(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Lines with id {id} not found!");
            }
            _unitOfWork.InvoiceLines.Remove(id);
            _unitOfWork.SaveChanges();
        }

        public void Update(InvoiceLine entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "InvoiceLine can't be null!");

            var existingAdmissionLine = GetById(entity.Id);
            if (existingAdmissionLine == null)
                throw new KeyNotFoundException($"InvoiceLine with ID {entity.Id} not found!");

            if (entity.Discount < 0)
                throw new InvalidOperationException("Discount is invalid!");

            if (entity.Quantity <= 0)
                throw new InvalidOperationException("Quantity is invalid!");

            _unitOfWork.InvoiceLines.Update(entity);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<InvoiceLine> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than 0.");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than 0.");

            return _unitOfWork.InvoiceLines.GetAll(pageNumber, pageSize);
        }

        public void RemovePermanently(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Lines with id {id} not found!");
            }
            _unitOfWork.InvoiceLines.RemovePermanently(id);
            _unitOfWork.SaveChanges();
        }

        public void Restore(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Lines with id {id} not found!");
            }
            _unitOfWork.InvoiceLines.Restore(id);
            _unitOfWork.SaveChanges();
        }

        public int Count()
        {
            return _unitOfWork.InvoiceLines.Count();
        }
    }
}
