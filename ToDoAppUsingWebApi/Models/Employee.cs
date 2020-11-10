using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoAppUsingWebApi.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
    }
}
