using Server.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace Server.Contracts
{
    public interface IEmployeeService
    {
        IQueryable <DbEmployee> List();
        int Add (DbEmployee employee) ;
        int Update(DbEmployee employee);
        int Remove(int id);
        DbEmployee Find(int id);
    }
}
