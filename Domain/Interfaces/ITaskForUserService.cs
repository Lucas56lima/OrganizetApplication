using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITaskForUserService
    {
        Task<TaskForUser> PostTaskForUser(TaskForUser taskforUser);
        Task<IEnumerable<TaskForUser>> GetTasksForUser();
        Task<TaskForUser> GetTaskForUserByTitle(string titleTaskForTitle);
        Task<TaskForUser> GetTaskForUserById(int idTaskForUser);
    }
}
