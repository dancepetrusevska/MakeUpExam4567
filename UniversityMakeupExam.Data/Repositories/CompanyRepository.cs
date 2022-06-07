using System.Collections.Generic;
using System.Linq;
using UniversityMakeupExam.Data.Entities;
using UniversityMakeupExam.Data.Interfaces;

namespace UniversityMakeupExam.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly MakeUpExam4567Context _MakeUpExam4567Context;

        public CompanyRepository(MakeUpExam4567Context MakeUpExam4567Context)
        {
            _MakeUpExam4567Context = MakeUpExam4567Context;
        }
        public IEnumerable<Company> GetCompany()
        {
            return _MakeUpExam4567Context.Companies.ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _MakeUpExam4567Context.Companies.FirstOrDefault(x => x.Id == id);
        }
    }
}
