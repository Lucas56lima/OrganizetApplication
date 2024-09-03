using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IStickNoteTaskService
    {
        Task<StickNoteTask> PostStickNoteTask(StickNoteTask stickNoteTask);
        Task<StickNoteTask> GetStickNoteTaskForStatus(string status);
        Task<StickNoteTask> GetStickNoteByTaskId(int taskId);
        Task<StickNoteTask> GetStickNoteById(int id);
        Task<IEnumerable<StickNoteTask>> GetAllStickNote();
        Task<StickNoteTask> PutStickNoteById(int id, StickNoteTask newStickNote);
    }
}
