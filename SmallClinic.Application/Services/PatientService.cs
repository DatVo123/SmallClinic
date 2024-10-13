using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using System.Linq.Expressions;

namespace SmallClinic.Application.Patients
{
    public class PatientService(IUnitOfWork unitOfWork) : IService<Patient>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public void Add(Patient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Patient can't be null!");

            if (IsExisted(s => s.Code == entity.Code))
                throw new InvalidOperationException($"Patient with code {entity.Code} already exists!");

            _unitOfWork.Patients.Add(entity);
        }

        public IEnumerable<Patient> Find(Expression<Func<Patient, bool>> predicate)
        {
            return _unitOfWork.Patients.Find(predicate);
        }

        public bool IsExisted(Expression<Func<Patient, bool>> predicate)
        {
            return _unitOfWork.Patients.IsExisted(predicate);
        }
        public IEnumerable<Patient> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than 0.");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than 0.");

            return _unitOfWork.Patients.GetAll(pageNumber, pageSize);
        }

        public Patient GetById(Guid id)
        {
            return _unitOfWork.Patients.GetById(id) ?? throw new KeyNotFoundException($"Patient with id {id} is not found!");
        }

        public void Update(Patient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Patient can't be null");

            var existingPatient = GetById(entity.Id);

            if (existingPatient.Code != entity.Code && IsExisted(s => s.Code == entity.Code))
            {
                throw new InvalidOperationException($"Patient with code {entity.Code} already exists!");
            }
            _unitOfWork.Patients.Update(entity);
            _unitOfWork.SaveChanges();
        }
        public void Remove(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Patient with id {id} not found!");
            }
            _unitOfWork.Patients.Remove(id);
            _unitOfWork.SaveChanges();
        }

        public void RemovePermanently(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Patient with id {id} not found!");
            }

            _unitOfWork.Patients.RemovePermanently(id);
            _unitOfWork.SaveChanges();
        }

        public void Restore(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Patient with id {id} not found!");
            }

            _unitOfWork.Patients.Restore(id);
            _unitOfWork.SaveChanges();
        }
        public int Count()
        {
            return _unitOfWork.Patients.Count();
        }

    }
}
