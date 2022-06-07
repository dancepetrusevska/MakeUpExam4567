using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Moq;
using UniversityMakeupExam.Data.Entities;
using UniversityMakeupExam.Data.Interfaces;
using UniversityMakeupExam.Models.DTO;
using UniversityMakeupExam.Service.Services;
using Xunit;

namespace UniversityMakeupExam.Tests
{
    public class UnitTest1
    {
        IEmployeeRepository EmployeeRepo;
        IMapper mapper;
        Mock<IEmployeeRepository> EmployeeRepoMock = new Mock<IEmployeeRepository>();
        Employee Employee;
        EmployeeDTO EmployeeDTO;
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        List<Employee> EmployeeList = new List<Employee>();
        List<EmployeeDTO> EmployeeDTOList = new List<EmployeeDTO>();
        [Fact]
        private void SetupMocks()
        {
            EmployeeRepo = EmployeeRepoMock.Object;
            mapper = mapperMock.Object;
        }

        private void SetupEmployeeDTOMocks()
        {
            Employee = GetEmployee();
            //var EmployeeDTO = GetEmployeeDTO();

            mapperMock.Setup(o => o.Map<EmployeeDTO>(Employee))
                .Returns(GetEmployeeDTO());
        }
        private void SetupEmployeeDTOListMocks()
        {
            EmployeeDTO = GetEmployeeDTO();
            var EmployeeDTO2 = GetEmployeeDTO();
            EmployeeDTO2.Id = 2;

            EmployeeDTOList.Add(EmployeeDTO);
            EmployeeDTOList.Add(EmployeeDTO2);

            EmployeeList = GetAllEmployee();

            mapperMock.Setup(o => o.Map<List<EmployeeDTO>>(EmployeeList))
                .Returns(EmployeeDTOList);
        }

        private static Employee GetEmployee()
        {
            return new Employee
            {
                Id = 4,
                FirstName = "Lyndsey",
                LastName = "Albers",
                Salary = "1415",
                SigningDate = DateTime.Today.AddYears(-1),
                Dob = DateTime.Today.AddYears(-20),
                CompanyId = 4
            };
        }

        private static EmployeeDTO GetEmployeeDTO()
        {
            return new EmployeeDTO
            {
                Id = 4,
                FirstName = "Lyndsey",
                LastName = "Albers",
                Salary = "1415",
                SigningDate = DateTime.Today.AddYears(-1),
                DOB = DateTime.Today.AddYears(-20),
                CompanyId = 4
            };
        }

        private static List<Employee> GetAllEmployee()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                Id = 1,
                CompanyId = 3,
                SigningDate = new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Local),
                FirstName = "Lyndsey",
                LastName = "Albers",
                Dob = DateTime.Today.AddYears(-20),
                Salary = "1415"
                },
                 new Employee()
                 {
                     Id = 2,
                     FirstName = "Christobel",
                     LastName = "Bezuidenhout",
                     Salary = "1241",
                     CompanyId = 5,
                     Dob = DateTime.Today.AddYears(-25),
                     SigningDate = DateTime.Today.AddYears(-4)
                 },
               new Employee()
               {
                   Id = 3,
                   FirstName = "Kristel",
                   LastName = "Madison",
                   Salary = "3121",
                   CompanyId = 1,
                   Dob = DateTime.Today.AddYears(-29),
                   SigningDate = DateTime.Today.AddYears(-2)
               }
            };
        }

        [Fact]
        public void GetEmployeeByIdWhenCalledReturnsEmployee()
        {
            //Arrange
            Employee = GetEmployee();
            SetupMocks();
            SetupEmployeeDTOMocks();

            EmployeeRepoMock
                .Setup(o => o.GetEmployeeById(It.IsAny<int>()))
                .Returns(Employee);

            var EmployeeService = new EmployeeService(EmployeeRepo, mapper);
            int id = 1;


            //Act 
            EmployeeDTO response = EmployeeService.GetEmployeeById(id);

            //Assert
            Assert.True(response != null);
            Assert.NotNull(response);
            Assert.Equal(4, response.Id);
            Assert.NotEqual(id, response.Id);
        }

        [Fact]
        public void GetEmployeesWhenCalledReturnsEmployee()
        {
            //Arrage 
            EmployeeList = GetAllEmployee();
            SetupMocks();
            SetupEmployeeDTOListMocks();

            EmployeeRepoMock
            .Setup(o => o.GetAllEmployees())
            .Returns(EmployeeList);

            var EmployeeService = new EmployeeService(EmployeeRepo, mapper);

            // Act
            List<EmployeeDTO> response = EmployeeService.GetEmployee();

            // Assert
            Assert.True(response != null);
        }

        [Fact]
        public void GetEmployeesWhenCalledOnThreeEmployeesReturnsTwoEmployee()
        {
            //Arrange
            EmployeeList = GetAllEmployee();
            SetupMocks();
            SetupEmployeeDTOListMocks();

            EmployeeRepoMock
                .Setup(o => o.GetAllEmployees())
                .Returns(EmployeeList);

            var EmployeeService = new EmployeeService(EmployeeRepo, mapper);

            //Act
            List<EmployeeDTO> response = EmployeeService.GetEmployee();

            //Assert
            Assert.NotNull(response);
            Assert.Equal(2, response.Count());
            Assert.NotEqual(1, response.Count());
        }
    }
}
