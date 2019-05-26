using Server.Contracts;
using Server.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataContext _context;

        public EmployeeService(IDataContext context)
        {
            _context = context;
        }

        public PagedResult<DbEmployee> List(DataRequest request)
        {
            var list = _context.GetAll<DbEmployee>();
            var result = list.ToPagedResult<DbEmployee>(request);
            return result;
        }

        public int Add(DbEmployee employee)
        {
            var b = _context.Create(employee);
            return b;
        }

        public int Update(DbEmployee employee)
        {
            var employ = _context.Find<DbEmployee>(employee.Id);
            if (employ == null) return 0;
            if (employ.Name != null) employ.Name = employee.Name;
            if (employ.Family != null) employ.Family = employee.Family;
            if (employ.Mname != null) employ.Mname = employee.Mname;
            if (employ.Year != null) employ.Year = employee.Year;
            if (employ.Email != null) employ.Email = employee.Email;
            var b = _context.Update(employ);
            return b;
        }

        public int Remove(int id)
        {
            var b = _context.Delete<DbEmployee>(id);
            return b;
        }

        public DbEmployee Find(int id)
        {
            var result = _context.GetAll<DbEmployee>().FirstOrDefault(a => a.Id == id);
            return result;

        }
    }
}
