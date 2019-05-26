using Server.Data;
using System.Linq;

namespace Server.Contracts
{
    public interface ILastWorkService
    {
        PagedResult<DbLastWork> List(DataRequest request);
        int Add(DbLastWork lastWork);
        int Update(DbLastWork lastWork);
        int Remove(int id);
        DbLastWork Find(int id);
    }
}
