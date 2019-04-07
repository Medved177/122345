using System;
using System.Collections.Generic;
using System.Text;
using Server.Data;
using System.Linq;

namespace Server.Contracts
{
    public interface IVacancyService
    {
        IQueryable<DbVacancy> List();
        int Add(DbVacancy vacancy);
        int Update(DbVacancy vacancy);
        int Remove(int id);
        DbVacancy Find(int id);
    }
}
