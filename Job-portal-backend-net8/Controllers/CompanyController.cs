using AutoMapper;
using Job_portal_backend_net8.Core.Context;
using Job_portal_backend_net8.Core.DTOs.Company;
using Job_portal_backend_net8.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_portal_backend_net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public CompanyController(IMapper mapper, ApplicationDbContext dbContext) 
        { 
            _mapper = mapper;
           _context = dbContext;
        }

        //create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDTO dto)
        {
            Company company = _mapper.Map<Company>(dto);
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();

            return Ok("Company Created Successfully");

        }
    }
}
