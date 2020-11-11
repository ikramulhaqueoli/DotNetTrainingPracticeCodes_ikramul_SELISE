using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAppUsingWebApi.Repositories
{
    public interface IRepository<T>
    {
        bool Add(T tEntity);
        bool Delete(int id);
        bool Update(T tEntity);
        T GetById(int id);
        List<T> GetAll();
        bool Commit();
    }
}
