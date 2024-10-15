using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using System.Linq.Expressions;

namespace SmallClinic.Application.Doctors
{
    public class DoctorService(IUnitOfWork unitOfWork) : IService<Doctor>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public void Add(Doctor entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Doctor can't be null!");

            if (IsExisted(s => s.Code == entity.Code))
                throw new InvalidOperationException($"Doctor with code {entity.Code} already exists!");

            _unitOfWork.Doctors.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Doctor> Find(Expression<Func<Doctor, bool>> predicate)
        {
            return _unitOfWork.Doctors.Find(predicate);
        }

        public bool IsExisted(Expression<Func<Doctor, bool>> predicate)
        {
            return _unitOfWork.Doctors.IsExisted(predicate);
        }
        public IEnumerable<Doctor> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than 0.");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than 0.");

            return _unitOfWork.Doctors.GetAll(pageNumber, pageSize);
        }

        public Doctor GetById(Guid id)
        {
            return _unitOfWork.Doctors.GetById(id) ?? throw new KeyNotFoundException($"Doctor with id {id} is not found!");
        }

        public void Update(Doctor entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Doctor can't be null");

            var existingDoctor = GetById(entity.Id);

            if (existingDoctor.Code != entity.Code && IsExisted(s => s.Code == entity.Code))
            {
                throw new InvalidOperationException($"Doctor with code {entity.Code} already exists!");
            }
            _unitOfWork.Doctors.Update(entity);
            _unitOfWork.SaveChanges();
        }
        public void Remove(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Doctor with id {id} not found!");
            }
            _unitOfWork.Doctors.Remove(id);
            _unitOfWork.SaveChanges();
        }

        public void RemovePermanently(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Doctor with id {id} not found!");
            }

            _unitOfWork.Doctors.RemovePermanently(id);
            _unitOfWork.SaveChanges();
        }

        public void Restore(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Doctor with id {id} not found!");
            }

            _unitOfWork.Doctors.Restore(id);
            _unitOfWork.SaveChanges();
        }
        public int Count()
        {
            return _unitOfWork.Doctors.Count();
        }

        public IEnumerable<Doctor> GetAllWithoutPaging()
        {
            throw new NotImplementedException();
        }
    }
}
