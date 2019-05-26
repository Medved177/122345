using Server.Data;
using System.Linq;

namespace Server.Contracts
{
    public interface IEmployeeService
    {
        PagedResult<DbEmployee> List(DataRequest request);
        int Add(DbEmployee employee);
        int Update(DbEmployee employee);
        int Remove(int id);
        DbEmployee Find(int id);
    }
}
