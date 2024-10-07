using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITaskForManyRepository
    {
        Task<TaskForMany> PostTaskForMany(TaskForMany taskforMany);
        Task<IEnumerable<TaskForMany>> GetTasksForMany();
        Task<TaskForMany> GetTaskForManyByTitle(string titleTaskForMany);
        Task<TaskForMany> GetTaskForManyById(int idTaskForMany);
        Task<TaskForMany> PutTaskForManyByIdAndSector(int id, TaskForMany taskForMany);  
    }
}
