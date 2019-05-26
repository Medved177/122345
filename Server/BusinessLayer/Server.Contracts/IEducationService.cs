using Server.Data;
using System.Linq;

namespace Server.Contracts
{
    public interface IEducationService
    {
        PagedResult<DbEducation> List(DataRequest request);
        int Add(DbEducation education);
        int Update(DbEducation education);
        int Remove(int id);
        DbEducation Find(int id);
    }
}
