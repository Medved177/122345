using System;
using System.Collections.Generic;
using System.Text;
using Server.Contracts;
using Server.Data;
using System.Linq;

namespace Server.Service
{
    public class EducationService : IEducationService
    {
        private readonly IDataContext _context;
        public EducationService(IDataContext context)
        {
            _context = context;
        }
        public int Add(DbEducation education)
        {
            var b = _context.Create(education);
            return b;
        }

        public DbEducation Find(int id)
        {
            var result = _context.GetAll<DbEducation>().FirstOrDefault(a => a.Id == id);
            return result;
        }

        public IQueryable<DbEducation> List()
        {
            var list = _context.GetAll<DbEducation>();
            return list;
        }

        public int Remove(int id)
        {
            var b = _context.Delete<DbEducation>(id);
            return b;
        }

        public int Update(DbEducation education)
        {
            var rem = _context.Find<DbEducation>(education.Id);
            if (rem == null) return 0;
            if (education.Type != null) rem.Type = education.Type;
            if (education.University != null) rem.University = education.University;
            if (education.Specialty != null) rem.Specialty = education.Specialty;
            if (education.View != null) rem.View = education.View;
            if (education.Employee != null) rem.Employee = education.Employee;
            var b = _context.Update(rem);
            return b;
        }
    }
}
