using Server.Contracts;
using Server.Data;
using System.Linq;

namespace Server.Services
{
    public class VacancySecrvice : IVacancyService
    {
        private readonly IDataContext _context;
        public VacancySecrvice(IDataContext context)
        {
            _context = context;
        }
        public int Add(DbVacancy vacancy)
        {
            var b = _context.Create(vacancy);
            return b;
        }

        public DbVacancy Find(int id)
        {
            var result = _context.GetAll<DbVacancy>().FirstOrDefault(a => a.Id == id);
            return result;
        }

        public IQueryable<DbVacancy> List()
        {
            var list = _context.GetAll<DbVacancy>();
            return list;
        }

        public int Remove(int id)
        {
            var b = _context.Delete<DbVacancy>(id);
            return b;
        }

        public int Update(DbVacancy vacancy)
        {
            var rem = _context.Find<DbVacancy>(vacancy.Id);
            if (rem == null) return 0;
            if (vacancy.Name != null) rem.Name = vacancy.Name;
            if (vacancy.Salary != null) rem.Salary = vacancy.Salary;
            if (vacancy.Education != null) rem.Education = vacancy.Education;
            if (vacancy.Experience != null) rem.Experience = vacancy.Experience;
            if (vacancy.Know != null) rem.Know = vacancy.Know;
            if (vacancy.Task != null) rem.Task = vacancy.Task;
            var b = _context.Update(rem);
            return b;
        }
    }
}
