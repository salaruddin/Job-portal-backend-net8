using AutoMapper;
using Job_portal_backend_net8.Core.Context;
using Job_portal_backend_net8.Core.DTOs.Candidate;
using Job_portal_backend_net8.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Job_portal_backend_net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CandidateController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDTO dto, IFormFile pdfFile)
        {

            // 1. Saving the input file in server
            string mimeType = "application/pdf";
            int maxSize = 5 * 1000 * 1000; //5 mb

            if(pdfFile.ContentType !=mimeType || pdfFile.Length>maxSize)
            {
                return BadRequest("File is not valid");
            }

            string fileName = Guid.NewGuid().ToString() + ".pdf";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),"documents","pdfs",fileName);

            using (var stream = new FileStream(filePath,FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }

            //2. Recording the data
            var candidate = _mapper.Map<Candidate>(dto);
            candidate.ResumeUrl = filePath;

            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();

            return Ok("Candidate Saved Successfully");
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidates()
        {
            var candidates = await _context.Candidates.Include(c=> c.Job).ToListAsync();
            IEnumerable<CandidateGetDTO> convertedCandidates = _mapper.Map<IEnumerable<CandidateGetDTO>>(candidates);

            return Ok(convertedCandidates);
        }

        // download pdf file, get the url and download that file
        [HttpGet]
        [Route("download/{filename}")]
        public IActionResult DownloadPdfFile(string filename)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),"documents","pdfs",filename);

            if(!System.IO.File.Exists(path))
            {
                return BadRequest("File not exists");
            }

            var pdfBytes = System.IO.File.ReadAllBytes(path);
            var file = File(pdfBytes, "application/pdf", filename);

            return file;



        }

    }
}
