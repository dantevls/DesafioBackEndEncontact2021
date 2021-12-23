using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Controllers.Models;
using TesteBackendEnContact.Core.Interface.ContactBook.Company;
using TesteBackendEnContact.Repository.Interface;

namespace TesteBackendEnContact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ICompany>> Post(SaveCompanyRequest company)
        {
            return Ok(await _companyRepository.SaveAsync(company.ToCompany()));
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _companyRepository.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ICompany>> Get()
        {
            return await _companyRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ICompany> Get(int id)
        {
            return await _companyRepository.GetAsync(id);
        }
    }
}
