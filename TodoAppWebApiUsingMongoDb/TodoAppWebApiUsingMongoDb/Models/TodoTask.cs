using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoAppWebApiUsingMongoDb.Models
{
    public class TodoTask : Entity
    {
        public TodoTask()
        {
            AssignedEmployees = new List<Employee>();
        }

        [MaxLength(40)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime AssignDate { get; set; }

        public ICollection<Employee> AssignedEmployees { private set; get; }
    }
}
