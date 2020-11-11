using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAppUsingWebApi.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _appDbContext;
        protected DbSet<T> _appDbSet;
        public Repository()
        {
            _appDbContext = new AppDbContext();
        }

        public bool Add(T tEntity)
        {
            if(_appDbSet.Add(tEntity) != null) return Commit();
            return false;
        }

        public bool Delete(int id)
        {
            if (_appDbSet.Remove(GetById(id)) != null) return Commit();
            return false;
        }

        public List<T> GetAll()
        {
            return _appDbSet.ToList();
        }

        public T GetById(int id)
        {
            return _appDbSet.Find(id);
        }

        public bool Update(T tEntity)
        {
            if(_appDbSet.Update(tEntity) != null) return Commit();
            return false;
        }

        public bool Commit()
        {
            return _appDbContext.SaveChanges() > 0
                ? true
                : false;
        }
    }
}
