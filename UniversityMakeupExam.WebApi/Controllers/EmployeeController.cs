using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityMakeupExam.Models.DTO;
using UniversityMakeupExam.Service.Interfaces;

namespace UniversityMakeupExam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;

        public EmployeeController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            var Employee = _EmployeeService.GetEmployee();

            return Employee;
        }

        [HttpGet]
        [Route("GetEmployeeById/{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            EmployeeDTO Employee = _EmployeeService.GetEmployeeById(id);

            if (Employee == null)
            {
                return NotFound("Employee with that id does not exist!");
            }

            return Ok(Employee);
        }

        [HttpDelete("RemoveEmployee/{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(_EmployeeService.DeleteEmployee(id));
            }
            return BadRequest();
        }

        [HttpPost("AddEmployee")]
        public IActionResult Post([FromBody] EmployeeDTO Employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = _EmployeeService.AddEmployee(Employee);
                return Created($"Employee with id {newEmployee.Id} is created", newEmployee.Id);
            }

            return UnprocessableEntity(ModelState);
        }

        [HttpPut("UpdateEmployee/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] EmployeeDTO Employee)
        {
            if (ModelState.IsValid)
            {
                Employee.Id = id;
                var result = _EmployeeService.UpdateEmployee(Employee);

                return result != null
                    ? Ok(result)
                    : NoContent();
            }
            return BadRequest();
        }
    }
}
