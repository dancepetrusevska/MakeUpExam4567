using AutoMapper;
using UniversityMakeupExam.Data.Entities;
using UniversityMakeupExam.Models.DTO;

namespace UniversityMakeupExam.Models.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDTO>()
                .ReverseMap();
        }
    }
}
