using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using System.Linq.Expressions;

namespace SmallClinic.Application.Invoices
{
    public class InvoiceService(IUnitOfWork unitOfWork) : IService<Invoice>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public void Add(Invoice entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Invoice can't be null!");

            if (IsExisted(s => s.Code == entity.Code))
                throw new InvalidOperationException($"Invoice with code {entity.Code} already exists!");

            _unitOfWork.Invoices.Add(entity);
        }

        public IEnumerable<Invoice> Find(Expression<Func<Invoice, bool>> predicate)
        {
            return _unitOfWork.Invoices.Find(predicate);
        }

        public bool IsExisted(Expression<Func<Invoice, bool>> predicate)
        {
            return _unitOfWork.Invoices.IsExisted(predicate);
        }
        public IEnumerable<Invoice> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than 0.");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than 0.");

            return _unitOfWork.Invoices.GetAll(pageNumber, pageSize);
        }

        public Invoice GetById(Guid id)
        {
            return _unitOfWork.Invoices.GetById(id) ?? throw new KeyNotFoundException($"Invoice with id {id} is not found!");
        }

        public void Update(Invoice entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Invoice can't be null");

            var existingInvoice = GetById(entity.Id);

            if (existingInvoice.Code != entity.Code && IsExisted(s => s.Code == entity.Code))
            {
                throw new InvalidOperationException($"Invoice with code {entity.Code} already exists!");
            }
            _unitOfWork.Invoices.Update(entity);
            _unitOfWork.SaveChanges();
        }
        public void Remove(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Invoice with id {id} not found!");
            }
            _unitOfWork.Invoices.Remove(id);
            _unitOfWork.SaveChanges();
        }

        public void RemovePermanently(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Invoice with id {id} not found!");
            }

            _unitOfWork.Invoices.RemovePermanently(id);
            _unitOfWork.SaveChanges();
        }

        public void Restore(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Invoice with id {id} not found!");
            }

            _unitOfWork.Invoices.Restore(id);
            _unitOfWork.SaveChanges();
        }
        public int Count()
        {
            return _unitOfWork.Invoices.Count();
        }

        public IEnumerable<Invoice> GetAllWithoutPaging()
        {
            throw new NotImplementedException();
        }
    }
}
