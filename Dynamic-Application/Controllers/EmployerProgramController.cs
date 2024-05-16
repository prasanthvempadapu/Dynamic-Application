using Dynamic_Application.Core;
using Dynamic_Application.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dynamic_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerProgramController : ControllerBase
    {
        private readonly IEmployerProgramRepository _employerProgramRepository;

        public EmployerProgramController(IEmployerProgramRepository employerProgramRepository)
        {
            _employerProgramRepository = employerProgramRepository;
        }
        [HttpGet("employerProgram")]
        public async Task<ActionResult<IEnumerable<EmployerProgram>>> GetAllTasks()
        {
            var employerProgram = await _employerProgramRepository.GetAllEmployerProgramAsync();
            if (employerProgram == null)// || !tasks.Any())
            {
                return NotFound();
            }

            return Ok(employerProgram);
        }
        [HttpGet("{programId}")]
        public async Task<ActionResult<EmployerProgram>> GetEmployer(string programId)
        {
            var employerProgram = await _employerProgramRepository.GetEmployerByIdAsync(programId);
            if (employerProgram == null)
            {
                return NotFound();
            }

            return employerProgram;
        }
        [HttpPost]
        public async Task<ActionResult<EmployerProgram>> CreateTask(EmployerProgram employerProgram)
        {
            // Set any additional properties if required
            employerProgram.Id = Guid.NewGuid().ToString();
            var createdEmployer = await _employerProgramRepository.CreateEmployerProgramAsync(employerProgram);
            return Created(createdEmployer.Id, createdEmployer);
            //return CreatedAtAction(nameof(GetEmployer), new { Id = createdEmployer.Id }, createdEmployer);
        }

        [HttpPut("{programId}")]
        public async Task<ActionResult<EmployerProgram>> UpdateTask(string programId, EmployerProgram task)
        {
            var existingTask = await _employerProgramRepository.GetEmployerByIdAsync(programId);
            if (existingTask == null)
            {
                return NotFound();
            }

            task.Id = existingTask.Id; // Preserve the original ID
            //task.ProgramTitle = existingTask.ProgramTitle;

            var updatedTask = await _employerProgramRepository.UpdateEmployerAsync(task);
            return Ok(updatedTask);
        }

        [HttpDelete("{programId}")]
        public async Task<IActionResult> DeleteUser(string programId)
        {
            var existingUser = await _employerProgramRepository.GetEmployerByIdAsync(programId);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _employerProgramRepository.DeleteEmployerProgramAsync(programId,existingUser.ProgramTitle);
            return NoContent();
        }
    }
}
