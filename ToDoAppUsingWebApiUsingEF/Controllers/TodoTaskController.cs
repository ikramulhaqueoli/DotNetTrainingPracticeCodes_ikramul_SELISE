using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoAppUsingWebApi.Models;
using ToDoAppUsingWebApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoAppUsingWebApi.Controllers
{
    [Route("api/todotask")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        TodoTaskRepository _todoTaskRepository = new TodoTaskRepository();
        EmployeeRepository _employeeRepository = new EmployeeRepository();

        // GET: api/<TodoTaskController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TodoTaskController>/5
        [HttpGet("{id}")]
        public TodoTask Get(int id)
        {
            return _todoTaskRepository.GetById(id);
        }

        // POST api/<TodoTaskController>
        [HttpPost]
        public void Post(TodoTask value)
        {
            _todoTaskRepository.Add(value);
        }

        // PUT api/<TodoTaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TodoTask value)
        {
            _todoTaskRepository.Update(value);
        }

        // DELETE api/<TodoTaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _todoTaskRepository.Delete(id);
        }
    }
}
