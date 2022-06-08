using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_CF_Jquery.Models
{
    public class Employee
    {
        [Key]
        public int Emp_ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public long Mobile { get; set; }
        public string Department { get; set; }
    }
}
