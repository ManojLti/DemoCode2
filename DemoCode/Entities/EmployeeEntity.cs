using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCode.Entities
{
    public class EmployeeEntity
    {
        [Required]
        public string ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Department { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Phone { get; set; }
    }
}
