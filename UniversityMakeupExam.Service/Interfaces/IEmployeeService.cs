using System.Collections.Generic;
using UniversityMakeupExam.Models.DTO;

namespace UniversityMakeupExam.Service.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetEmployee();
        EmployeeDTO GetEmployeeById(int id);
        EmployeeDTO AddEmployee(EmployeeDTO Employee);
        EmployeeDTO UpdateEmployee(EmployeeDTO Employee);
        bool DeleteEmployee(int id);
    }
}
