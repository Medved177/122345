using Server.Contracts;
using Server.Data;
using System.Linq;

namespace Server.Services
{
    public class LastWorkService : ILastWorkService
    {
        private readonly IDataContext _context;
        public LastWorkService(IDataContext context)
        {
            _context = context;
        }
        public int Add(DbLastWork lastWork)
        {
            var b = _context.Create(lastWork);
            return b;
        }

        public DbLastWork Find(int id)
        {
            var result = _context.GetAll<DbLastWork>().FirstOrDefault(a => a.Id == id);
            return result;
        }

        public IQueryable<DbLastWork> List()
        {
            var list = _context.GetAll<DbLastWork>();
            return list;
        }

        public int Remove(int id)
        {
            var b = _context.Delete<DbLastWork>(id);
            return b;
        }

        public int Update(DbLastWork lastWork)
        {
            var rem = _context.Find<DbLastWork>(lastWork.Id);
            if (rem == null) return 0;
            if (lastWork.Name != null) rem.Name = lastWork.Name;
            if (lastWork.Experience != null) rem.Experience = lastWork.Experience;
            if (lastWork.Employee != null) rem.Employee = lastWork.Employee;
            var b = _context.Update(rem);
            return b;
        }
    }
}
