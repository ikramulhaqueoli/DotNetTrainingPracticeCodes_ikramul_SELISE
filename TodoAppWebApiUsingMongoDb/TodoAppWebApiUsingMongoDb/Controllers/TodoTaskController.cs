using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TodoAppWebApiUsingMongoDb.Models;
using TodoAppWebApiUsingMongoDb.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAppWebApiUsingMongoDb.Controllers
{
    [Route("api/todotask")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        TodoTaskRepository _todoTaskRepository = new TodoTaskRepository();
        EmployeeRepository _employeeRepository = new EmployeeRepository();

        // GET: api/<TodoTaskController>
        [HttpGet("all")]
        public List<TodoTask> Get()
        {
            return _todoTaskRepository.GetAll();
        }

        // GET api/<TodoTaskController>/5
        [HttpGet("get/{id}")]
        public TodoTask Get(string id)
        {
            return _todoTaskRepository.GetById(id);
        }

        // POST api/<TodoTaskController>
        [HttpPost("add")]
        public void Post(TodoTask value)
        {
            _todoTaskRepository.Add(value);
        }

        // PUT api/<TodoTaskController>/5
        [HttpPut("update/{id}")]
        public void Put(int id, [FromBody] TodoTask value)
        {
            _todoTaskRepository.Replace(value);
        }

        // DELETE api/<TodoTaskController>/5
        [HttpDelete("delete/{id}")]
        public void Delete(string id)
        {
            _todoTaskRepository.Delete(id);
        }

        [HttpGet("TasksDeadlineUpto/{date}")]
        public List<TodoTask> TasksDeadlineUpto(string date)
        {
            IEnumerable<TodoTask> tasks =   from t in _todoTaskRepository.GetAll()
                                            where t.DeadLine <= DateTime.Parse(date)
                                            select t;
            return tasks.ToList();
        }

        [HttpGet("AssignTaskTo/{taskId}/{employeeId}")]
        public bool AssignTaskTo(string taskId, string employeeId)
        {
            var todoTask = _todoTaskRepository.GetAll().Find(t => t.Id == taskId);
            if (todoTask == null || !_employeeRepository.GetAll().Any(e => e.Id == employeeId)) 
                return false;

            todoTask.AssignedEmployees.Add(employeeId);
            _todoTaskRepository.Replace(todoTask);
            return true;
        }

        [HttpGet("TaskAssignedTo/{id}")]
        public List<Employee> TaskAssignedTo(string id)
        {
            var task = (from t in _todoTaskRepository.GetAll()
                                          where t.Id == id
                                          select t).FirstOrDefault();
            List<Employee> employees = new List<Employee>();
            if (task == null) return employees;
            foreach(string employeeId in task.AssignedEmployees)
            {
                employees.Add( _employeeRepository.GetById(employeeId) );
            }
            return employees;
        }

        [HttpGet("CompleteTask/{id}")]
        public bool CompleteTask(string id)
        {
            var task = (from t in _todoTaskRepository.GetAll()
                        where t.Id == id
                        select t).FirstOrDefault();
            TodoTask todoTask = _todoTaskRepository.GetAll().Find(t => t.Id == id);
            if (todoTask == null) return false;
            todoTask.CompletionStatus = true;
            _todoTaskRepository.Replace(todoTask);
            return true;
        }

        [HttpGet("RemainingTasks")]
        public List<TodoTask> RemainingTasks()
        {
            var tasks = (from t in _todoTaskRepository.GetAll()
                        where t.CompletionStatus == false
                        select t).ToList();
            return tasks;
        }
    }
}
