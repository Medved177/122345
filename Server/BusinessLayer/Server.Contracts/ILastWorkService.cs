using Server.Data;
using System.Linq;

namespace Server.Contracts
{
    public interface ILastWorkService
    {
        IQueryable<DbLastWork> List();
        int Add(DbLastWork lastWork);
        int Update(DbLastWork lastWork);
        int Remove(int id);
        DbLastWork Find(int id);
    }
}
