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
            if (taskforMany.Description == null)
                taskforMany.Description = "";

            if (taskforMany == null)
            {
                return null;
            }

            taskforMany.CreateDate = DateOnly.FromDateTime(DateTime.Now);
            taskforMany.CreateHour = DateTime.Now.TimeOfDay.ToString();
            return _repository.PostTaskForMany(taskforMany);
        }

        public async Task<TaskForMany> PutTaskForManyByIdAndSector(int id, TaskForMany taskForMany)
        {
            TaskForMany taskForManyDb = await GetTaskForManyById(id);

            taskForMany.Id = taskForManyDb.Id;
            taskForMany.CreateDate = taskForManyDb.CreateDate;
            taskForMany.Description = taskForManyDb.Description;
            taskForMany.CreatorUserId = taskForManyDb.CreatorUserId;
            taskForMany.IsActive = taskForManyDb.IsActive;
            
            
            return await _repository.PutTaskForManyByIdAndSector(id, taskForMany);
        }
    }
}
