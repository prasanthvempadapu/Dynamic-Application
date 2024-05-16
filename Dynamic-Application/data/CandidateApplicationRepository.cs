using Dynamic_Application.Core;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace Dynamic_Application.data
{
    public class CandidateApplicationRepository : ICandidateApplicationRepository
    {
        private readonly Container _taskContainer;
        private readonly IConfiguration configuration;
        public CandidateApplicationRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.configuration = configuration;

            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            var taskContainerName = "CandidateApplication";
            _taskContainer = cosmosClient.GetContainer(databaseName, taskContainerName);
        }
        public async Task<IEnumerable<CandidateApplication>> GetAllCandidateApplicationAsync()
        {
            var query = _taskContainer.GetItemLinqQueryable<CandidateApplication>()
                .ToFeedIterator();

            var candidateApplication = new List<CandidateApplication>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                candidateApplication.AddRange(response);
            }

            return candidateApplication;
        }
        public async Task<CandidateApplication> GetCandidateApplicationByIdAsync(string candidateId)
        {
            var query = _taskContainer.GetItemLinqQueryable<CandidateApplication>()
            .Where(t => t.Id == candidateId)
            .Take(1)
            .ToQueryDefinition();

            var sqlQuery = query.QueryText; // Retrieve the SQL query

            var response = await _taskContainer.GetItemQueryIterator<CandidateApplication>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }
        public async Task<CandidateApplication> CreateCandidateApplicationAsync(CandidateApplication candidateApplication)
        {
            var response = await _taskContainer.CreateItemAsync(candidateApplication);
            return response.Resource;
        }


        public async Task DeleteCandidateApplicationAsync(string candidateId, string firstName)
        {
            await _taskContainer.DeleteItemAsync<CandidateApplication>(candidateId, new PartitionKey(firstName));

        }
    }
}
