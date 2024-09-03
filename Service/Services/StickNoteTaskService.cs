using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StickNoteTaskService(IStickNoteTaskRepository repository) : IStickNoteTaskService
    {
        private readonly IStickNoteTaskRepository _repository = repository;

        public async Task<IEnumerable<StickNoteTask>> GetAllStickNote()
        {
            return await _repository.GetAllStickNote();
        }

        public async Task<StickNoteTask> GetStickNoteById(int id)
        {
            var stickNoteTaskDb = await _repository.GetStickNoteById(id);
            if (stickNoteTaskDb == null)
            {
                return null;
            }
            return stickNoteTaskDb;
        }

        public async Task<StickNoteTask> GetStickNoteByTaskId(int taskId)
        {
            var stickNoteTaskDb = await _repository.GetStickNoteByTaskId(taskId);
            if (stickNoteTaskDb == null)
            {
                return null;
            }
            return stickNoteTaskDb;
        }

        public async Task<StickNoteTask> GetStickNoteTaskForStatus(string status)
        {
            var stickNoteTaskDb = await _repository.GetStickNoteTaskForStatus(status);
            if (stickNoteTaskDb == null)
            {
                return null;
            }
            return stickNoteTaskDb;
        }

        public Task<StickNoteTask> PostStickNoteTask(StickNoteTask stickNoteTask)
        {
            if (stickNoteTask == null)
            {
                return null;
            }
            return _repository.PostStickNoteTask(stickNoteTask);
        }

        public async Task<StickNoteTask> PutStickNoteById(int id, StickNoteTask newStickNote)
        {
            StickNoteTask stickNoteTaskDb = await GetStickNoteById(id);
            newStickNote.TaskId = id;
            return await _repository.PutStickNoteById(id, newStickNote);
        }
    }
}
