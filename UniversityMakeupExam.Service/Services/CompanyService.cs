using System.Collections.Generic;
using UniversityMakeupExam.Data.Entities;
using UniversityMakeupExam.Data.Interfaces;
using UniversityMakeupExam.Service.Interfaces;

namespace UniversityMakeupExam.Service.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _CompanyRepository;

        public CompanyService(ICompanyRepository CompanyRepository)
        {
            _CompanyRepository = CompanyRepository;
        }
        public IEnumerable<Company> GetCompany()
        {
            return _CompanyRepository.GetCompany();
        }

        public Company GetCompanyById(int id)
        {
            return _CompanyRepository.GetCompanyById(id);
        }
    }
}
