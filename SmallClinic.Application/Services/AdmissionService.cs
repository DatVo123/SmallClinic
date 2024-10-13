using SmallClinic.Application.Doctors;
using SmallClinic.Application.Invoices;
using SmallClinic.Application.Patients;
using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using System.Linq.Expressions;

namespace SmallClinic.Application.Admissions
{
    public class AdmissionService(IUnitOfWork unitOfWork, IService<Doctor> doctorService, IService<Patient> patientService, IService<Invoice> invoiceService) : IService<Admission>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly IService<Doctor> _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
        private readonly IService<Patient> _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        private readonly IService<Invoice> _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));
        public void Add(Admission entity)
        {

            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Admission can't be null!");

            if (!_patientService.IsExisted(p => p.Code == entity.Patient.Code))
            {
                _patientService.Add(entity.Patient);
            }
            if (!_doctorService.IsExisted(d=> d.Code == entity.Doctor.Code))
                _doctorService.Add(entity.Doctor);


            if (IsExisted(s => s.Code == entity.Code))
                throw new InvalidOperationException($"Admission with code {entity.Code} already exists!");

            _unitOfWork.Admissions.Add(entity);
            _unitOfWork.SaveChanges();

            // Tạo Invoice
            var invoice = new Invoice(
                date: DateTime.Now,
                amount: CalculateInvoiceAmount(entity),
                discount: null,
                netAmount: CalculateNetAmount(entity),
                patientId: entity.PatientId,
                invoiceStatusId: Guid.NewGuid(),
                prommoteId: null,
                admissionId: entity.Id
            );
            _unitOfWork.SaveChanges();
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

    }
}
