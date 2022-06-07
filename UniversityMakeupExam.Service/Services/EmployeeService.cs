using System.Collections.Generic;
using AutoMapper;
using UniversityMakeupExam.Data.Entities;
using UniversityMakeupExam.Data.Interfaces;
using UniversityMakeupExam.Models.DTO;
using UniversityMakeupExam.Service.Interfaces;

namespace UniversityMakeupExam.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeService(IEmployeeRepository EmployeeRepository, IMapper mapper)
        {
            _EmployeeRepository = EmployeeRepository;
            _mapper = mapper;
        }

        public EmployeeDTO AddEmployee(EmployeeDTO Employee)
        {
            Employee newEmployee = _mapper.Map<Employee>(Employee);

            if (_EmployeeRepository.GetEmployeeById(Employee.Id) == null)
            {
                _EmployeeRepository.AddEmployee(newEmployee);
            }
            return _mapper.Map<EmployeeDTO>(newEmployee);
        }

        public bool DeleteEmployee(int id)
        {
            var EmployeeEntity = _EmployeeRepository.GetEmployeeById(id);

            /* 
            var CompanyEntity = await _MakeUpExam4567Context.Company.FindAsync(EmployeeEntity.CompanyId);
            
            var CompanyWithEmployee = await _MakeUpExam4567Context.Employee.Where(s => s.Id == EmployeeEntity.Company.Id).ToListAsync();
            foreach(var Employee in EmployeeWithCompany)
            {
                _MakeUpExam4567Context.Employee.Remove(Employee);
            }

            _MakeUpExam4567Context.Company.Remove(CompanyEntity);
            */

            return _EmployeeRepository.DeleteEmployee(EmployeeEntity);
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            //Would cause circular dependency error, so we need DTOs
            //return await _MakeUpExam4567Context.Employee.Include(s => s.Company).FirstOrDefaultAsync(x => x.Id == id);

            var Employee = _EmployeeRepository.GetEmployeeById(id);
            return _mapper.Map<EmployeeDTO>(Employee);
        }

        public List<EmployeeDTO> GetEmployee()
        {
            //1. Entities
            //return await _MakeUpExam4567Context.Employee.ToListAsync();

            //2. DTOs
            //return _MakeUpExam4567Context.Employee.Select(x => new EmployeeDTO
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    DOB = x.DOB,
            //    EnrollmentDate = x.EnrollmentDate,
            //    StudentIndex = x.StudentIndex,
            //    GPA = x.GPA,
            //    Mail = x.Mail,
            //    AddressId = x.AddressId,
            //    Address = new AddressDTO
            //    {
            //        Id = x.Company.Id,
            //        Street = x.Company.Street,
            //        City = x.Company.City,
            //        Country = x.Company.Country
            //    }
            //}).ToList();

            //3. AutoMapper DTOs
            var Employee = _EmployeeRepository.GetAllEmployees();
            return _mapper.Map<List<EmployeeDTO>>(Employee);
        }

        public EmployeeDTO UpdateEmployee(EmployeeDTO Employee)
        {
            Employee newEmployee = _mapper.Map<Employee>(Employee);
          //  Employee oldEmployee = _EmployeeRepository.GetEmployeeById(newEmployee.Id);

            //if (oldEmployee != null)
            //{
            //    _EmployeeRepository.UpdateEmployee(oldEmployee, newEmployee);
            //}
            return _mapper.Map<EmployeeDTO>(newEmployee);
        }
    }
}
