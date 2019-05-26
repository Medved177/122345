using Server.Data;
using System.Linq;

namespace Server.Contracts
{
    public interface IResultService
    {
        PagedResult<DbResult> List(DataRequest request);
        int Add(DbResult Result);
        int Update(DbResult Result);
        int Remove(int id);
        DbResult Find(int id);
    }
}
