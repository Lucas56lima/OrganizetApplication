using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;

namespace Service.Services
{
    public class TaskForUserService(ITaskForUserRepository repository) : ITaskForUserService
    {
        private readonly ITaskForUserRepository _repository = repository;
        
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

        public async Task<IEnumerable<TaskViewModel>> GetTasksForUser()
        {
            return await _repository.GetTasksForUser();
        }

        public async Task<IEnumerable<TaskViewModel>> GetTasksForUserCompleted(DateOnly initialDate, DateOnly endDate)
        {
            return await _repository.GetTasksForUserCompleted(initialDate, endDate);
        }

        public Task<TaskForUser> PostTaskForUser(TaskForUser taskforUser)
        {
            if(taskforUser.Description == null)
                taskforUser.Description = "";
            if (taskforUser == null)
            {
                return null;
            }
            taskforUser.CreateDate = DateOnly.FromDateTime(DateTime.Now);
            taskforUser.CreateHour = DateTime.Now.TimeOfDay.ToString();
            return _repository.PostTaskForUser(taskforUser);
        }
    }
}
