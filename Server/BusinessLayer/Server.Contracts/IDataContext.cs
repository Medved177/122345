using System.Linq;

namespace Server.Contracts
{
    public interface IDataContext
    {
        IQueryable<T> GetAll<T>() where T : class, new();
        int Create<T>(T model) where T : class, new();
        int Update<T>(T model) where T : class, new();
        int Delete<T>(int id) where T : class, new();
        T Find<T>(int id) where T : class, new();
    }
}
