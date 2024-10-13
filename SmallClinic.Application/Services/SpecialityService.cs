using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using System.Linq.Expressions;

namespace smallclinic.application.services
{
    public class SpecialityService(IUnitOfWork unitOfWork) : IService<Speciality>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public void Add(Speciality entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Service can't be null!");

            if (IsExisted(s => s.Code == entity.Code))
                throw new InvalidOperationException($"Service with code {entity.Code} already exists!");

            _unitOfWork.Specialities.Add(entity);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<Speciality> Find(Expression<Func<Speciality, bool>> predicate)
        {
            return _unitOfWork.Specialities.Find(predicate);
        }

        public IEnumerable<Speciality> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1)
                throw new ArgumentOutOfRangeException("Invalid page");
            return _unitOfWork.Specialities.GetAll(pageNumber, pageSize);
        }

        public Speciality GetById(Guid id)
        {
            return _unitOfWork.Specialities.GetById(id) ?? throw new KeyNotFoundException($"Speciality with ID : {id} not found!");
        }
        public void Update(Speciality entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity),"Speciality can't be null!");
            var existingSpe = GetById(entity.Id);

            if (existingSpe.Code != entity.Code && IsExisted(s => s.Code == entity.Code))
                throw new InvalidOperationException($"Service with code {entity.Code} already exists!");
            _unitOfWork.Specialities.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public bool IsExisted(Expression<Func<Speciality, bool>> predicate)
        {
            return _unitOfWork.Specialities.IsExisted(predicate);
        }

        public void Remove(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Speciality with id {id} not found!");
            }
            _unitOfWork.Specialities.Remove(id);
            _unitOfWork.SaveChanges();
        }

        public void RemovePermanently(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Speciality with id {id} not found!");
            }
            _unitOfWork.Specialities.RemovePermanently(id);
            _unitOfWork.SaveChanges();
        }

        public void Restore(Guid id)
        {
            if (!IsExisted(s => s.Id == id))
            {
                throw new KeyNotFoundException($"Speciality with id {id} not found!");
            }
            _unitOfWork.Specialities.Restore(id);
            _unitOfWork.SaveChanges();
        }
        public int Count()
        {
            return _unitOfWork.Specialities.Count();
        }
    }
}
