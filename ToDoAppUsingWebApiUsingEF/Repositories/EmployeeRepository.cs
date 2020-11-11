using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAppUsingWebApi.Models;

namespace ToDoAppUsingWebApi.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository()
        {
            this._appDbSet = _appDbContext.Employees;
        }

        public static EmployeeRepository Instance => new EmployeeRepository();
    }
}
