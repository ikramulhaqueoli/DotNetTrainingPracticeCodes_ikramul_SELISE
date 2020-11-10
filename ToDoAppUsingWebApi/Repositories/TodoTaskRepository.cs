using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAppUsingWebApi.Models;

namespace ToDoAppUsingWebApi.Repositories
{
    public class TodoTaskRepository : Repository<TodoTask>
    {
        public TodoTaskRepository()
        {
            this._appDbSet = _appDbContext.TodoTasks;
        }

        public static TodoTaskRepository Instance => new TodoTaskRepository();
    }
}
