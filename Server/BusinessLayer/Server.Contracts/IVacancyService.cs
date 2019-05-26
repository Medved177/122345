using Server.Data;
using System.Linq;

namespace Server.Contracts
{
    public interface IVacancyService
    {
        PagedResult<DbVacancy> List(DataRequest request);
        int Add(DbVacancy vacancy);
        int Update(DbVacancy vacancy);
        int Remove(int id);
        DbVacancy Find(int id);
    }
}
