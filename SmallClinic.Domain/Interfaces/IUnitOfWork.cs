using SmallClinic.Domain.Entities;
using SmallClinic.Infrastructure.Repositories;

namespace SmallClinic.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Admission> Admissions { get; }
        IRepository<AdmissionLine> AdmissionLines { get; }
        IRepository<Patient> Patients { get; }
        IRepository<Doctor> Doctors { get; }
        IRepository<Service> Services { get; }
        IRepository<Speciality> Specialities { get; }
        IRepository<User> Users { get; }
        IRepository<Invoice> Invoices { get; }
        IRepository<InvoiceLine> InvoiceLines { get; }
        IRepository<Promote> Promotes { get; }

        void SaveChanges();
    }
}
