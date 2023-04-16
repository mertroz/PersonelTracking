﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonnelTrackingSystem.DataAccess;

#nullable disable

namespace PersonnelTrackingSystem.DataAccess.Migrations
{
    [DbContext(typeof(PersonnelTrackingSystemContext))]
    partial class PersonnelTrackingSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonnelTrackingSystem.Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Address");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Department");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint")
                        .HasColumnName("Gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("HiringDate");

                    b.Property<int>("HomePhone")
                        .HasMaxLength(20)
                        .HasColumnType("int")
                        .HasColumnName("HomePhone");

                    b.Property<int>("Identity")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("Identity");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName");

                    b.Property<int>("MobilePhone")
                        .HasMaxLength(20)
                        .HasColumnType("int")
                        .HasColumnName("MobilePhone");

                    b.Property<int>("RegistrationNumber")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("RegistrationNumber");

                    b.HasKey("Id");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("PersonnelTrackingSystem.Domain.SalaryCalculator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Bonus")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("Bonus");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    b.Property<decimal>("MealAllowance")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("MealAllowance");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("Salary");

                    b.Property<decimal>("TransportationAllowance")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("TransportationAllowance");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("SalaryCalculators", (string)null);
                });

            modelBuilder.Entity("PersonnelTrackingSystem.Domain.SalaryPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("SalaryPayments");
                });

            modelBuilder.Entity("PersonnelTrackingSystem.Domain.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    b.Property<DateTime>("WorkingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("WorkingDate");

                    b.Property<DateTime>("WorkingTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("WorkingTime");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Shift", (string)null);
                });

            modelBuilder.Entity("PersonnelTrackingSystem.Domain.SalaryCalculator", b =>
                {
                    b.HasOne("PersonnelTrackingSystem.Domain.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PersonnelTrackingSystem.Domain.SalaryPayment", b =>
                {
                    b.HasOne("PersonnelTrackingSystem.Domain.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PersonnelTrackingSystem.Domain.Shift", b =>
                {
                    b.HasOne("PersonnelTrackingSystem.Domain.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
