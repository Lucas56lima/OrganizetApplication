using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class TaskForManySectorService(ITaskForManySectorRepository repository) : ITaskForManySectorService
    {
        private readonly ITaskForManySectorRepository _repository = repository;

        public Task<IEnumerable<TaskForManySector>> GetTaskForManySector()
        {
            throw new NotImplementedException();
        }

        public Task<TaskForManySector> GetTaskForManySectorByTaskId(int idTask)
        {
            throw new NotImplementedException();
        }

        public Task<TaskForManySector> PostTaskForManySector(TaskForManySector taskForManySector)
        {
            throw new NotImplementedException();
        }
    }
}
