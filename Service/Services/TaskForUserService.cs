using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class TaskForUserService : ITaskForUserService
    {
        private readonly ITaskForUserRepository _repository;
        public TaskForUserService(ITaskForUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskForUser> GetTaskForUserById(int idTaskForUser)
        {
            var taskForManyDb = await _repository.GetTaskForUserById(idTaskForUser);
            if (taskForManyDb == null)
            {
                return null;
            }
            return taskForManyDb;
        }

        public async Task<TaskForUser> GetTaskForUserByTitle(string titleTaskForTitle)
        {
            var taskForManyDb = await _repository.GetTaskForUserByTitle(titleTaskForTitle);
            if (taskForManyDb == null)
            {
                return null;
            }
            return taskForManyDb;
        }

        public Task<IEnumerable<TaskForUser>> GetTasksForUser()
        {
            return _repository.GetTasksForUser();
        }

        public Task<TaskForUser> PostTaskForUser(TaskForUser taskforUser)
        {
            if (taskforUser == null)
            {
                return null;
            }
            return _repository.PostTaskForUser(taskforUser);
        }
    }
}
