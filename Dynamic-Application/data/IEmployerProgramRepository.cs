using Dynamic_Application.Core;

namespace Dynamic_Application.data
{
    public interface IEmployerProgramRepository
    {
        Task<IEnumerable<EmployerProgram>> GetAllEmployerProgramAsync();
        Task<EmployerProgram> CreateEmployerProgramAsync(EmployerProgram employerProgram);
        //Task DeleteEmployerProgramAsync(string programId);
        Task<EmployerProgram> GetEmployerByIdAsync(string programId);
        Task<EmployerProgram> UpdateEmployerAsync(EmployerProgram employerProgram);

    }
}
