using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;

namespace Service.Services
{
    public class TaskForManySectorService(ITaskForManySectorRepository repository) : ITaskForManySectorService
    {
        private readonly ITaskForManySectorRepository _repository = repository;

        public async Task<IEnumerable<int>> GetSectorsByTaskId(int idTask)
        {
            var sectors = await _repository.GetSectorsByTaskId(idTask);
            if (sectors == null)
            {
                return Enumerable.Empty<int>();
            }

            return sectors;
        }

        public async Task<IEnumerable<TaskViewModel>> GetTaskForManySector(int sectorId)
        {
            var tasksForManySector = await _repository.GetTaskForManySector(sectorId);
            if (tasksForManySector == null)
            {
                return Enumerable.Empty<TaskViewModel>();
            }

            return tasksForManySector;
        }

        public async Task <IEnumerable<TaskViewModel>> GetTaskForManySectorByTaskId(int idTask)
        {
            var tasksForManySector = await _repository.GetTaskForManySectorByTaskId(idTask);
            if (tasksForManySector == null)
            {
                return null;
            }

            return tasksForManySector;
        }

        public async Task<IEnumerable<TaskViewModel>> GetTasksForManySectorCompleted(int sectorId, DateOnly initialDate, DateOnly endDate)
        {
            var tasksForManySector = await _repository.GetTasksForManySectorCompleted(sectorId,initialDate,endDate);
            if (tasksForManySector == null)
            {
                return Enumerable.Empty<TaskViewModel>();
            }

            return tasksForManySector;
        }

        public async Task<TaskForManySector> PostTaskForManySector(TaskForManySector taskForManySector)
        {
            return await _repository.PostTaskForManySector(taskForManySector);
        }
    }
}
