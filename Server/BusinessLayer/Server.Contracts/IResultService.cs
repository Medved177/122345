﻿using Server.Data;
using System.Linq;

namespace Server.Contracts
{
    public interface IResultService
    {
        IQueryable<DbResult> List();
        int Add(DbResult Result);
        int Update(DbResult Result);
        int Remove(int id);
        DbResult Find(int id);
    }
}
