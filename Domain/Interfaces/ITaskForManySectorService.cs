using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ITaskForManySectorService
    {
        Task<TaskForManySector> PostTaskForManySector(TaskForManySector taskForManySector);
        Task<IEnumerable<TaskViewModel>> GetTaskForManySector(int sectorId);
        Task<IEnumerable<TaskViewModel>> GetTaskForManySectorByTaskId(int idTask);
        Task<IEnumerable<int>> GetSectorsByTaskId(int idTask);
        Task<IEnumerable<TaskViewModel>> GetTasksForManySectorCompleted(int sectorId, DateOnly initialDate, DateOnly endDate);
    }
}
