using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoAppWebApiUsingMongoDb.Models
{
    public class Employee : Entity
    {
        [MaxLength(40)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
    }
}
