using AutoMapper;
using Job_portal_backend_net8.Core.Context;
using Job_portal_backend_net8.Core.DTOs.Job;
using Job_portal_backend_net8.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Job_portal_backend_net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public JobController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CreateJob([FromBody] JobCreateDTO dto)
        {
            Job job = _mapper.Map<Job>(dto);
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();

            return Ok("Job Created Successfully");
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<JobGetDTO>>> GetJobs()
        {
            var jobs = await _context.Jobs.Include(j=> j.Company).OrderByDescending(j=> j.CreatedAt).ToListAsync();
            IEnumerable<JobGetDTO> convertedJobs = _mapper.Map<IEnumerable<JobGetDTO>>(jobs);

            return Ok(convertedJobs);
        }
    }
}
