﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmallClinic.Infrastructure.Data;

#nullable disable

namespace SmallClinic.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241011063803_UpdateDB2")]
    partial class UpdateDB2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmallClinic.Domain.Entities.Admission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdmissionStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SequenceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdmissionStatusId")
                        .IsUnique();

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("SequenceId")
                        .IsUnique();

                    b.ToTable("Admissions");
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.AdmissionLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdmissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdmissionStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdmissionId");

                    b.HasIndex("AdmissionStatusId");

                    b.HasIndex("ServiceId");

                    b.ToTable("AdmissionLines");
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.AdmissionStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdmissionStatus");
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SpecialityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.SequenceNumber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdmissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrentValue")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdmissionId");

                    b.ToTable("SequenceNumbers");
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.Speciality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("SmallClinic.Domain.ValueObjects.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae16350a-867c-46e3-9ca7-08d352be7c40"),
                            GenderId = "Male",
                            IsDeleted = false,
                            Name = "Male"
                        },
                        new
                        {
                            Id = new Guid("a90dd0e8-b071-4d2b-96d0-65c021ae6c98"),
                            GenderId = "FeMale",
                            IsDeleted = false,
                            Name = "FeMale"
                        },
                        new
                        {
                            Id = new Guid("ee979224-efb2-43d6-9acb-f5ec22c3df84"),
                            GenderId = "Other",
                            IsDeleted = false,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.Admission", b =>
                {
                    b.HasOne("SmallClinic.Domain.Entities.AdmissionStatus", "AdmissionStatus")
                        .WithOne()
                        .HasForeignKey("SmallClinic.Domain.Entities.Admission", "AdmissionStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmallClinic.Domain.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmallClinic.Domain.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmallClinic.Domain.Entities.SequenceNumber", "SequenceNumber")
                        .WithOne()
                        .HasForeignKey("SmallClinic.Domain.Entities.Admission", "SequenceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AdmissionStatus");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("SequenceNumber");
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.AdmissionLine", b =>
                {
                    b.HasOne("SmallClinic.Domain.Entities.Admission", "Admission")
                        .WithMany("AdmissionLines")
                        .HasForeignKey("AdmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmallClinic.Domain.Entities.AdmissionStatus", "AdmissionStatus")
                        .WithMany()
                        .HasForeignKey("AdmissionStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmallClinic.Domain.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admission");

                    b.Navigation("AdmissionStatus");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("SmallClinic.Domain.ValueObjects.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmallClinic.Domain.Entities.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.Patient", b =>
                {
                    b.HasOne("SmallClinic.Domain.ValueObjects.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.SequenceNumber", b =>
                {
                    b.HasOne("SmallClinic.Domain.Entities.Admission", "Admission")
                        .WithMany()
                        .HasForeignKey("AdmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admission");
                });

            modelBuilder.Entity("SmallClinic.Domain.Entities.Admission", b =>
                {
                    b.Navigation("AdmissionLines");
                });
#pragma warning restore 612, 618
        }
    }
}
