using System;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Contracts;
using System.Linq;
using System.Collections.Generic;

namespace Server.DataAccess
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<DbEmployee> Employees { get; set; }
        public DbSet<DbEducation> Education { get; set; }
        public DbSet<DbVacancy> Vacancies { get; set; }
        public DbSet<DbResult> Results { get; set; }
        public DbSet<DbLastWork> LastWork { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbEmployee>().HasData(
                new DbEmployee[]
                {
                    new DbEmployee { Id = 1,Family = "Иванов", Name = "Иван",  Mname = "Иванович" , Email = "Ivanov@mail.ru",Year = 25 },
                    new DbEmployee { Id = 2, Family = "Петров", Name = "Петр",  Mname = "Петрович" , Email = "Petrov@mail.ru",Year = 24 },
                    new DbEmployee { Id = 3, Family = "Николайченко", Name = "Николай",  Mname = "Николаевич" , Email = "Nick@mail.ru",Year = 25},
                    new DbEmployee { Id = 4, Family = "Борисов", Name = "Сергей",  Mname = "Борисович" , Email = "Borisov@mail.ru",Year = 30},
                    new DbEmployee { Id = 5, Family = "Антонова", Name = "Антонина",  Mname = "Степановна" , Email = "Antonova@mail.ru",Year = 27},
                });
            base.OnModelCreating(modelBuilder);
        }


        public int Create<T>(T model) where T : class, new()
        {
            Set<T>().Add(model);
            var result = SaveChanges();
            return result;
        }

        public int Delete<T>(int id) where T : class, new()
        {
            var rem = Set<T>().Find(id);
            if (rem != null)
            {
                Set<T>().Remove(rem);
                var result = SaveChanges();
                return result;
            }
            return 0;

        }

        public T Find<T>(int id) where T : class, new()
        {
            var rem = Set<T>().Find(id);
            return rem;
        }

        public IQueryable<T> GetAll<T>() where T : class, new()
        {
            var query = Set<T>().ToList();
            return query.AsQueryable();
        }

        int IDataContext.Update<T>(T model)
        {
            Set<T>().Update(model);
            var result = SaveChanges();
            return result;
        }
    }
}
