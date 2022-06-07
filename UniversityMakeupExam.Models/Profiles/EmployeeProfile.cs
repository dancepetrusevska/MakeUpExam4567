using AutoMapper;
using UniversityMakeupExam.Data.Entities;
using UniversityMakeupExam.Models.DTO;

namespace UniversityMakeupExam.Models.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ReverseMap();
        }
    }
}
