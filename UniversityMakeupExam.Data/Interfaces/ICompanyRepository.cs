using System.Collections.Generic;
using UniversityMakeupExam.Data.Entities;

namespace UniversityMakeupExam.Data.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetCompany();
        Company GetCompanyById(int id);
    }
}
