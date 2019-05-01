using Server.Data;
using System.Linq;

namespace Server.Contracts
{
    public interface IEducationService
    {
        IQueryable<DbEducation> List();
        int Add(DbEducation education);
        int Update(DbEducation education);
        int Remove(int id);
        DbEducation Find(int id);
    }
}
