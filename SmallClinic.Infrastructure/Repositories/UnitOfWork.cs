using SmallClinic.Domain.Entities;
using SmallClinic.Domain.Interfaces;
using SmallClinic.Infrastructure.Data;

namespace SmallClinic.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); 
            Admissions = new Repository<Admission>(_context);
            AdmissionLines = new Repository<AdmissionLine>(_context);
            Patients = new Repository<Patient>(_context);
            Doctors = new Repository<Doctor>(_context);
            Services = new Repository<Service>(_context);
            Specialities = new Repository<Speciality>(_context);
            Invoices = new Repository<Invoice>(_context);
            InvoiceLines = new Repository<InvoiceLine>(_context);
            Promotes = new Repository<Promote>(_context);   

            Users = new Repository<User>(_context); 
        }

        public IRepository<Admission> Admissions { get; private set; }
        public IRepository<AdmissionLine> AdmissionLines { get; private set; }
        public IRepository<Patient> Patients { get; private set; }
        public IRepository<Doctor> Doctors { get; private set; }
        public IRepository<Service> Services { get; private set; }
        public IRepository<Speciality> Specialities { get; private set; }
        public IRepository<Invoice> Invoices { get; private set; }
        public IRepository<InvoiceLine> InvoiceLines { get; private set; }
        public IRepository<Promote> Promotes { get; private set; }
        public IRepository<User> Users { get; private set; }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
