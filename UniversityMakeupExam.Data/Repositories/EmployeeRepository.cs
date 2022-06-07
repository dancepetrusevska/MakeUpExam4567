using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityMakeupExam.Data.Entities;
using UniversityMakeupExam.Data.Interfaces;

namespace UniversityMakeupExam.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MakeUpExam4567Context _MakeUpExam4567Context;

        public EmployeeRepository(MakeUpExam4567Context MakeUpExam4567Context)
        {
            _MakeUpExam4567Context = MakeUpExam4567Context;
        }
        public void AddEmployee(Employee Employee)
        {
            _MakeUpExam4567Context.Employees.Add(Employee);
            Save();
        }

        public bool DeleteEmployee(Employee Employee)
        {
            try
            {
                _MakeUpExam4567Context.Employees.Remove(Employee);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Employee GetEmployeeById(int id)
        {
            return _MakeUpExam4567Context.Employees.Include(s => s.Company).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _MakeUpExam4567Context.Employees.Include(s => s.Company);
        }

        public void UpdateEmployee(Employee oldEmployee, Employee newEmployee)
        {
            _MakeUpExam4567Context.Entry(oldEmployee).CurrentValues.SetValues(newEmployee);
            Save();
        }
        public void Save()
        {
            _MakeUpExam4567Context.SaveChangesAsync();
        }
    }
}
