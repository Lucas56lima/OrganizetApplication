using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITaskForManySectorRepository
    {
        Task<TaskForManySector> PostTaskForManySector(TaskForManySector taskForManySector);
        Task<IEnumerable<TaskForManySector>> GetTaskForManySector();
        Task<TaskForManySector> GetTaskForManySectorByTaskId(int idTask);
    }
}
