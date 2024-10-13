using Microsoft.EntityFrameworkCore;
using SmallClinic.Domain.Entities;
using SmallClinic.Domain.ValueObjects;
using System.Linq.Expressions;

namespace SmallClinic.Infrastructure.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<AdmissionStatus> AdmissionStatus { get; set; }
        public DbSet<AdmissionLine> AdmissionLines { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoicesLine { get; set; }
        public DbSet<InvoiceStatus> InvoicesStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình Bệnh nhân
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Gender)
                .WithMany()
                .HasForeignKey(p => p.GenderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình Bác sĩ
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Gender)
                .WithMany()
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Speciality)
                .WithMany()
                .HasForeignKey(d => d.SpecialityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình Lịch khám
            modelBuilder.Entity<Admission>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Admissions)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Admission>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Admissions)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Admission>()
                .HasOne(a => a.AdmissionStatus)
                .WithMany()
                .HasForeignKey(a => a.AdmissionStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình AdmissionLine
            modelBuilder.Entity<AdmissionLine>()
                .HasOne(al => al.Admission)
                .WithMany(a => a.AdmissionLines)
                .HasForeignKey(al => al.AdmissionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdmissionLine>()
                .HasOne(al => al.Service)
                .WithMany()
                .HasForeignKey(al => al.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
            //Cấu hình Invoice
            modelBuilder.Entity<Invoice>()
                .HasOne(inv => inv.Admission)
                .WithMany(a => a.Invoices)
                .HasForeignKey(inv => inv.AdmissionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invoice>()
                .HasOne(inv => inv.Patient)
                .WithMany()
                .HasForeignKey(inv => inv.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invoice>()
                .HasOne(inv => inv.Promote)
                .WithMany()
                .HasForeignKey(inv => inv.PrommoteId);
            modelBuilder.Entity<Invoice>()
                .HasOne(inv => inv.InvoiceStatus)
                .WithMany()
                .HasForeignKey(inv => inv.InvoiceStatusId);
            //Cấu hình InoviceLine
            modelBuilder.Entity<InvoiceLine>()
                .HasOne(inv => inv.Service)
                .WithMany()
                .HasForeignKey(inv => inv.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InvoiceLine>()
                .HasOne(invl => invl.Invoice)
                .WithMany(inv => inv.InvoiceLines)
                .HasForeignKey(invl => invl.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdmissionStatus>().HasData(
                new AdmissionStatus("Admitted", "Đã đăng ký"),    
                new AdmissionStatus("Completed", "Hoàn thành"),    
                new AdmissionStatus("Canclled", "Đã hủy") 
                );

            modelBuilder.Entity<InvoiceStatus>().HasData(
               new InvoiceStatus("UnPay", "Chờ thu"),
               new InvoiceStatus("Paid", "Đã thu"),
               new InvoiceStatus("Canclled", "Đã hủy"));

            modelBuilder.Entity<Gender>().HasData(
                new Gender("Male","Male"),
                new Gender("FeMale", "FeMale"),
                new Gender("Other", "Other")
            );
        }

        // Hàm lọc cho xóa mềm
        private static LambdaExpression ConvertFilter(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");
            var body = Expression.Equal(Expression.Property(parameter, "IsDeleted"), Expression.Constant(false));
            return Expression.Lambda(body, parameter);
        }
    }
}
