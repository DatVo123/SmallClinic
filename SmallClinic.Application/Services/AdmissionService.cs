using SmallClinic.Application.Doctors;
using SmallClinic.Application.Interfaces;
using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using System.Linq.Expressions;

namespace SmallClinic.Application.Admissions
{
    public class AdmissionService : IService<Admission>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdmissionService(
                    IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public void Add(Admission entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Admission entity can't be null");

          
            entity.Code = GenerateAdmissionCode();
            _unitOfWork.Admissions.Add(entity);
            _unitOfWork.SaveChanges();  

        }
        string GenerateAdmissionCode()
        {
            var lastAdmission = _unitOfWork.Admissions.GetAllWithoutPaging().OrderByDescending(a => a.Code).FirstOrDefault();
            if (lastAdmission == null)
            {
                return "ADM001";
            }
            var lastCode = lastAdmission.Code.Substring(3);
            var nextCode = int.Parse(lastCode) + 1;

            return $"ADM{nextCode:D3}";
        }
        string GenerateInvoiceCode()
        {
            var lastAdmission = _unitOfWork.Invoices.GetAllWithoutPaging().OrderByDescending(a => a.Code).FirstOrDefault();
            if (lastAdmission == null)
            {
                return "INV001";
            }
            var lastCode = lastAdmission.Code.Substring(3);
            var nextCode = int.Parse(lastCode) + 1;

            return $"INV{nextCode:D3}";
        }
        private decimal CalculateInvoiceAmount(Admission admission)
        {
            return admission.AdmissionLines.Sum(line => line.Amount);
        }

        private decimal CalculateNetAmount(Admission admission)
        {
            var amount = CalculateInvoiceAmount(admission);
            var discount = 0m;
            return amount - discount;
        }

        public IEnumerable<Admission> Find(Expression<Func<Admission, bool>> predicate)
        {
            return _unitOfWork.Admissions.Find(predicate);
        }

        public bool IsExisted(Expression<Func<Admission, bool>> predicate)
        {
            return _unitOfWork.Admissions.IsExisted(predicate);
        }

        public IEnumerable<Admission> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than 0.");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than 0.");

            return _unitOfWork.Admissions.GetAll(pageNumber, pageSize);
        }

        public Admission GetById(Guid id)
        {
            return _unitOfWork.Admissions.GetById(id) ?? throw new KeyNotFoundException($"Admission with id {id} is not found!");
        }

        public void Update(Admission entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Admission can't be null");

            var existedAdmission = GetById(entity.Id);

            if (existedAdmission.Code != entity.Code && IsExisted(s => s.Code == entity.Code))
            {
                throw new InvalidOperationException($"Admission with code {entity.Code} already exists!");
            }
            _unitOfWork.Admissions.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public void Remove(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Admission with id {id} not found!");
            }
            _unitOfWork.Admissions.Remove(id);
            _unitOfWork.SaveChanges();
        }

        public void RemovePermanently(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Admission with id {id} not found!");
            }

            _unitOfWork.Admissions.RemovePermanently(id);
            _unitOfWork.SaveChanges();
        }

        public void Restore(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Admission with id {id} not found!");
            }

            _unitOfWork.Admissions.Restore(id);
            _unitOfWork.SaveChanges();
        }

        public int Count()
        {
            return _unitOfWork.Admissions.Count();
        }

        public IEnumerable<Admission> GetAllWithoutPaging()
        {
            return _unitOfWork.Admissions.GetAllWithoutPaging();
        }
    }
}
