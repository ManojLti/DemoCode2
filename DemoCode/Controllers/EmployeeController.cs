using DemoCode.Entities;
using DemoCode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoCode.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeController:ControllerBase
    {
        //swagger
        /// <summary>
        /// Get details of All Employees.
        /// </summary>
        /// <returns>Peek the details of employee</returns>
        /// <remarks> Demo API Get implementation</remarks>
        //swagger

        [HttpGet]
        public IActionResult GetEmployee()
        {
            string output = new SBService().PeekEmployee();
            if (output!=null)
            {
                return Content(output);
            }
            return Ok("No Content Found");
        }


        //swagger
        /// <summary>
        /// Add new Employee
        /// </summary>
       /// <param name="emp.name">Name of the employee</param>
        /// <returns>Peek the details of employee</returns>
        /// <remarks> Name should not have more than 20 characters and phone should not have more than 10 char</remarks>
        //swagger


        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeEntity emp)
        {
            String Email = emp.Email;
            bool isEmail = Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                return BadRequest("Invalid Email");
            }
            EmployeeEntity emp2 = new EmployeeEntity()
            {
                ID=emp.ID,
                Name=emp.Name,
                Department=emp.Department,
                Email=emp.Email,
                Phone=emp.Phone

            };
            int output=new SBService().AddEmployee(emp2);
            if(output==1)
            {
                return CreatedAtAction("AddEmployee",emp2);
            }
            return StatusCode(500,emp2);
        }

    }
}
