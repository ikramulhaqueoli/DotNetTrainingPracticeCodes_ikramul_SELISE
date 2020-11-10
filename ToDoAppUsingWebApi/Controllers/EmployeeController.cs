using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoAppUsingWebApi.Models;
using ToDoAppUsingWebApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoAppUsingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        TodoTaskRepository _todoTaskRepository = new TodoTaskRepository();
        EmployeeRepository _employeeRepository = new EmployeeRepository();
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id:min(1)}")]
        public Employee Get(int id)
        {
            return _employeeRepository.GetById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public bool Post([FromBody] Employee value)
        {
            return _employeeRepository.Add(value);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id:min(1)}")]
        public bool Put(int id, [FromBody] Employee value)
        {
            value.Id = id;
            return _employeeRepository.Update(value);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id:min(1)}")]
        public bool Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }
    }
}
