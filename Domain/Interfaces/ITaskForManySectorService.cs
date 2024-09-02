using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITaskForManySectorService
    {
        Task<TaskForManySector> PostTaskForManySector(TaskForManySector taskForManySector);
        Task<IEnumerable<TaskForManySector>> GetTaskForManySector();
        Task<TaskForManySector> GetTaskForManySectorByTaskId(int idTask);
    }
}
