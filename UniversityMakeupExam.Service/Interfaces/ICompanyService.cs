using System.Collections.Generic;
using UniversityMakeupExam.Data.Entities;

namespace UniversityMakeupExam.Service.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetCompany();
        Company GetCompanyById(int id);

    }
}
