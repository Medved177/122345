using Server.Contracts;
using Server.Data;
using System.Linq;

namespace Server.Services
{
    public class ResultService : IResultService
    {
        private readonly IDataContext _context;
        public ResultService(IDataContext context)
        {
            _context = context;
        }
        public int Add(DbResult Result)
        {
            var b = _context.Create(Result);
            return b;
        }

        public DbResult Find(int id)
        {
            var result = _context.GetAll<DbResult>().FirstOrDefault(a => a.Id == id);
            return result;
        }

        public PagedResult<DbResult> List(DataRequest request)
        {
            var list = _context.GetAll<DbResult>();
            var result = list.ToPagedResult<DbResult>(request);
            return result;
        }

        public int Remove(int id)
        {
            var b = _context.Delete<DbResult>(id);
            return b;
        }

        public int Update(DbResult Result)
        {
            var rem = _context.Find<DbResult>(Result.Id);
            if (rem == null) return 0;
            if (Result.Test != null) rem.Test = Result.Test;
            if (Result.Result1 != null) rem.Result1 = Result.Result1;
            if (Result.Employee != null) rem.Employee = Result.Employee;
            if (Result.Vacancy != null) rem.Vacancy = Result.Vacancy;
            var b = _context.Update(rem);
            return b;
        }
    }
}
