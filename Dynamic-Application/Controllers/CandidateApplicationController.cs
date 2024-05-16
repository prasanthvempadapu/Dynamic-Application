using Dynamic_Application.Core;
using Dynamic_Application.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dynamic_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateApplicationController : ControllerBase
    {
        private readonly ICandidateApplicationRepository _candidateApplicationRepository;
        public CandidateApplicationController(ICandidateApplicationRepository candidateApplicationRepository)
        {
            _candidateApplicationRepository = candidateApplicationRepository;
        }
        [HttpGet("candidateApplication")]
        public async Task<ActionResult<IEnumerable<CandidateApplication>>> GetAllTasks()
        {
            var candidateApplication = await _candidateApplicationRepository.GetAllCandidateApplicationAsync();
            if (candidateApplication == null)// || !tasks.Any())
            {
                return NotFound();
            }

            return Ok(candidateApplication);
        }
        [HttpGet("{candidateId}")]
        public async Task<ActionResult<CandidateApplication>> GetEmployer(string candidateId)
        {
            var candidateApplication = await _candidateApplicationRepository.GetCandidateApplicationByIdAsync(candidateId);
            if (candidateApplication == null)
            {
                return NotFound();
            }

            return candidateApplication;
        }
        [HttpPost]
        public async Task<ActionResult<CandidateApplication>> CreateTask(CandidateApplication candidateApplication)
        {
            // Set any additional properties if required
            candidateApplication.Id = Guid.NewGuid().ToString();
            var createdCandidate = await _candidateApplicationRepository.CreateCandidateApplicationAsync(candidateApplication);
            return Created(createdCandidate.Id, createdCandidate);
            //return CreatedAtAction(nameof(GetEmployer), new { Id = createdEmployer.Id }, createdEmployer);
        }

        [HttpDelete("{candidateId}")]
        public async Task<IActionResult> DeleteUser(string candidateId)
        {
            var existingUser = await _candidateApplicationRepository.GetCandidateApplicationByIdAsync(candidateId);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _candidateApplicationRepository.DeleteCandidateApplicationAsync(candidateId, existingUser.FirstName);
            return NoContent();
        }
    }
}
