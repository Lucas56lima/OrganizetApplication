using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class TaskForManyService(ITaskForManyRepository repository) : ITaskForManyService
    {
        private readonly ITaskForManyRepository _repository = repository;

        public async Task<TaskForMany> GetTaskForManyById(int idTaskForMany)
        {
            var taskForManyDb = await _repository.GetTaskForManyById(idTaskForMany);
            if(taskForManyDb == null)
            {
                return null;
            }
            return taskForManyDb;
        }

        public async Task<TaskForMany> GetTaskForManyByTitle(string titleTaskForMany)
        {
            var taskForManyDb = await _repository.GetTaskForManyByTitle(titleTaskForMany);
            if (taskForManyDb == null)
            {
                return null;
            }
            return taskForManyDb;
        }

        public Task<IEnumerable<TaskForMany>> GetTasksForMany()
        {
            return _repository.GetTasksForMany();
        }

        public Task<TaskForMany> PostTaskForMany(TaskForMany taskforMany)
        {
            if (taskforMany == null)
            {
                return null;
            }
            return _repository.PostTaskForMany(taskforMany);
        }
    }
}
