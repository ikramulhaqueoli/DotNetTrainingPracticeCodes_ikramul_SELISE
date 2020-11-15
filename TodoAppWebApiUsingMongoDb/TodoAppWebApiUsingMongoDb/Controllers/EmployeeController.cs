using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoAppWebApiUsingMongoDb.Models;
using TodoAppWebApiUsingMongoDb.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAppWebApiUsingMongoDb.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        TodoTaskRepository _todoTaskRepository = new TodoTaskRepository();
        EmployeeRepository _employeeRepository = new EmployeeRepository();
        // GET: api/<EmployeeController>
        [HttpGet("all")]
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("get/{id}")]
        public Employee Get(string id)
        {
            return _employeeRepository.GetById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost("add")]
        public void Post([FromBody] Employee value)
        {
            _employeeRepository.Add(value);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("update/{id}")]
        public void Put(string id, [FromBody] Employee value)
        {
            value.Id = id;
            _employeeRepository.Replace(value);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("delete/{id}")]
        public void Delete(string id)
        {
            _employeeRepository.Delete(id);
        }

    }
}
