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
        public DbSet<DbTest> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbVacancy>().HasData(
                new DbVacancy[]
                {
                    new DbVacancy { Id = 1,Name = "Младший программист", Salary = 25000,  Education = "Высшее" , Know = "опыт работы и знание особенностей одного из JS-фреймворков (Knockout, Backbone, Marionette JS, AngularJS, jQuery);",Task = "работать с большими и сложными проектами" },
                    new DbVacancy { Id = 2,Name = "Младший программист", Salary = 25000,  Education = "Высшее" , Know = "опыт работы и знание особенностей одного из JS-фреймворков (Knockout, Backbone, Marionette JS, AngularJS, jQuery);",Task = "работать с большими и сложными проектами" },
                    new DbVacancy { Id = 3,Name = "Младший программист", Salary = 25000,  Education = "Высшее" , Know = "опыт работы и знание особенностей одного из JS-фреймворков (Knockout, Backbone, Marionette JS, AngularJS, jQuery);",Task = "работать с большими и сложными проектами" },
                    new DbVacancy { Id = 4,Name = "Младший программист", Salary = 25000,  Education = "Высшее" , Know = "опыт работы и знание особенностей одного из JS-фреймворков (Knockout, Backbone, Marionette JS, AngularJS, jQuery);",Task = "работать с большими и сложными проектами" },
                    new DbVacancy { Id = 5,Name = "Младший программист", Salary = 25000,  Education = "Высшее" , Know = "опыт работы и знание особенностей одного из JS-фреймворков (Knockout, Backbone, Marionette JS, AngularJS, jQuery);",Task = "работать с большими и сложными проектами" },
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
