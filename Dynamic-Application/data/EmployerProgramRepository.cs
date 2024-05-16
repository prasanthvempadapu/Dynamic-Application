using Dynamic_Application.Core;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Dynamic_Application.data
{
    public class EmployerProgramRepository : IEmployerProgramRepository
    {
        private readonly Container _taskContainer;
        private readonly IConfiguration configuration;
        public EmployerProgramRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.configuration = configuration;

            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            var taskContainerName = "EmployerProgram";
            _taskContainer = cosmosClient.GetContainer(databaseName, taskContainerName);
        }
        public async Task<IEnumerable<EmployerProgram>> GetAllEmployerProgramAsync()
        {
            var query = _taskContainer.GetItemLinqQueryable<EmployerProgram>()
                .ToFeedIterator();

            var employerProgram = new List<EmployerProgram>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                employerProgram.AddRange(response);
            }

            return employerProgram;
        }
        public async Task<EmployerProgram> GetEmployerByIdAsync(string programId)
        {
            var query = _taskContainer.GetItemLinqQueryable<EmployerProgram>()
            .Where(t => t.Id == programId)
            .Take(1)
            .ToQueryDefinition();

            var sqlQuery = query.QueryText; // Retrieve the SQL query

            var response = await _taskContainer.GetItemQueryIterator<EmployerProgram>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }
        public async Task<EmployerProgram> CreateEmployerProgramAsync(EmployerProgram employerProgram)
        {
            var response = await _taskContainer.CreateItemAsync(employerProgram);
            return response.Resource;
        }

        public async Task<EmployerProgram> UpdateEmployerAsync(EmployerProgram employerProgram)
        {
            var response = await _taskContainer.ReplaceItemAsync(employerProgram, employerProgram.Id,new PartitionKey(employerProgram.ProgramTitle));
            return response.Resource;
        }

        public async Task DeleteEmployerProgramAsync(string programId,string programTitle)
        {
            await _taskContainer.DeleteItemAsync<EmployerProgram>(programId, new PartitionKey(programTitle));

        }

    }
}
