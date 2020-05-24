using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DropdownProject.Models.Commen;
using DropdownProject.Repo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DropdownProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("GetEmployees")]
        public List<Models.Commen.Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }


        [HttpPost("AddEmployee")]
        public int AddEmployee([FromBody] Employee emp1)
        {
            return _employeeRepository.SaveEmployee(emp1);
        }


        //************
        //Department
        //************

        [HttpGet("GetDepartments")]
        public List<Models.Commen.Department> GetDepartments()
        {
            return _employeeRepository.GetDepartment();
        }

    }
}