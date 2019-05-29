﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.DataAccess;

namespace Server.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Server.Data.DbEducation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Specialty");

                    b.Property<string>("Type");

                    b.Property<string>("University");

                    b.Property<string>("View");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("Server.Data.DbEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Family");

                    b.Property<string>("Mname");

                    b.Property<string>("Name");

                    b.Property<int?>("Year");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new { Id = 1, Email = "Ivanov@mail.ru", Family = "Иванов", Mname = "Иванович", Name = "Иван", Year = 25 },
                        new { Id = 2, Email = "Petrov@mail.ru", Family = "Петров", Mname = "Петрович", Name = "Петр", Year = 24 },
                        new { Id = 3, Email = "Nick@mail.ru", Family = "Николайченко", Mname = "Николаевич", Name = "Николай", Year = 25 },
                        new { Id = 4, Email = "Borisov@mail.ru", Family = "Борисов", Mname = "Борисович", Name = "Сергей", Year = 30 },
                        new { Id = 5, Email = "Antonova@mail.ru", Family = "Антонова", Mname = "Степановна", Name = "Антонина", Year = 27 }
                    );
                });

            modelBuilder.Entity("Server.Data.DbLastWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId");

                    b.Property<int?>("Experience");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("LastWork");
                });

            modelBuilder.Entity("Server.Data.DbResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Result1");

                    b.Property<int?>("Test");

                    b.Property<int?>("VacancyId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VacancyId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Server.Data.DbVacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Education");

                    b.Property<int?>("Experience");

                    b.Property<string>("Know");

                    b.Property<string>("Name");

                    b.Property<int?>("Salary");

                    b.Property<string>("Task");

                    b.HasKey("Id");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("Server.Data.DbEducation", b =>
                {
                    b.HasOne("Server.Data.DbEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Server.Data.DbLastWork", b =>
                {
                    b.HasOne("Server.Data.DbEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Server.Data.DbResult", b =>
                {
                    b.HasOne("Server.Data.DbEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Server.Data.DbVacancy", "Vacancy")
                        .WithMany()
                        .HasForeignKey("VacancyId");
                });
#pragma warning restore 612, 618
        }
    }
}