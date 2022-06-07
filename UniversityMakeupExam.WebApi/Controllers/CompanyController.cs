using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityMakeupExam.Data.Entities;
using UniversityMakeupExam.Service.Interfaces;

namespace UniversityMakeupExam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _CompanyService;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger, ICompanyService CompanyService)
        {
            _CompanyService = CompanyService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllCompanyes")]
        public IEnumerable<Company> GetCompanyes()
        {
            var Companyes = _CompanyService.GetCompany();

            return Companyes;
        }

        [HttpGet]
        [Route("GetCompanyById/{id:int}")]
        public IActionResult GetCompanyById(int id)
        {
            Company Company = _CompanyService.GetCompanyById(id);

            if (Company == null)
            {
                return NotFound("Company with that id does not exist!");
            }

            return Ok(Company);
        }
    }
}
