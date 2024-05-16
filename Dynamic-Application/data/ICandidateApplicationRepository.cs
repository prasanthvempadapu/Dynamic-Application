using Dynamic_Application.Core;

namespace Dynamic_Application.data
{
    public interface ICandidateApplicationRepository
    {
        Task<IEnumerable<CandidateApplication>> GetAllCandidateApplicationAsync();
        Task<CandidateApplication> CreateCandidateApplicationAsync(CandidateApplication candidateApplication);
        Task DeleteCandidateApplicationAsync(string candidateId, string firstName);
        Task<CandidateApplication> GetCandidateApplicationByIdAsync(string candidateId);
    }
}
