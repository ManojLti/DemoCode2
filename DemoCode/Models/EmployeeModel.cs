﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCode.Models
{
    public class EmployeeModel
    {
         public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Department { get; set; }
        
        public string Email { get; set; }
        public int Phone { get; set; }

    }
}
