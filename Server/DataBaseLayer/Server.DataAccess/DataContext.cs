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
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<DbEmployee>  Employees { get ; set ; }
        public DbSet<DbEducation> Education { get ; set; }
        public DbSet<DbVacancy> Vacancies { get; set; }
        public DbSet<DbResult> Results { get ; set ; }
        public DbSet<DbLastWork> LastWork { get; set ; }

        public int Create<T>(T model) where T : class, new()
        {
            Set<T>().Add(model);
            var result = SaveChanges();
            return result;
        }

        public int Delete<T> (int id) where T : class, new()
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

        public new T Find<T>(int id) where T : class, new()
        {
            var rem = Set<T>().Find(id);
            return rem;
        }

        public IQueryable<T> GetAll<T>() where T : class, new()
        {
            var query = Set<T>().ToList();
            return query.AsQueryable();
        }

        public int Update<T>(T model) where T : class, new()
        {
               Set<T>().Update(model);
                var result = SaveChanges();
                return result;
        }
    }
}
