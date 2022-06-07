using System.Collections.Generic;
using UniversityMakeupExam.Data.Entities;

namespace UniversityMakeupExam.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee Employee);
        void UpdateEmployee(Employee oldEmployee, Employee newEmployee);
        bool DeleteEmployee(Employee Employee);
    }
}
