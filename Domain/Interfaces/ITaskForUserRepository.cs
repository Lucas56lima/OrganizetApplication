using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ITaskForUserRepository
    {
        Task<TaskForUser> PostTaskForUser(TaskForUser taskforUser);
        Task<IEnumerable<TaskViewModel>> GetTasksForUser();
        Task<TaskForUser> GetTaskForUserByTitle(string titleTaskForTitle);
        Task<TaskForUser> GetTaskForUserById(int idTaskForUser);
        Task<IEnumerable<TaskViewModel>> GetTasksForUserCompleted(DateOnly initialDate, DateOnly endDate);
    }
}
