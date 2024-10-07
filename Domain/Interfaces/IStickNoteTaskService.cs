using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IStickNoteTaskService
    {
        Task<StickNoteTaskForMany> PostStickNoteTask(StickNoteTaskForMany stickNoteTask);
        Task<StickNoteTaskForUserBackUp> PostStickNoteTaskForUser(StickNoteTaskForUserBackUp stickNoteTaskForUser);
        Task<IEnumerable<StickNoteViewModel>> GetStickNoteTaskForStatus(int taskId,string status);
        Task<IEnumerable<StickNoteTaskForMany>> GetStickNoteTaskForStatusAndSector(int taskId, string status,int sectorId);
        Task<IEnumerable<StickNoteViewModel>> GetStickNoteByTaskId(int taskId);
        Task<StickNoteTaskForMany> GetStickNoteById(int id);
        Task<IEnumerable<StickNoteTaskForMany>> GetAllStickNote();
        Task<StickNoteTaskForMany> PutStickNoteById(int id, StickNoteTaskForMany newStickNote);
        Task<StickNoteTaskForUserBackUp> PutStickNoteByIdForUser(int sitckNoteId, StickNoteTaskForUserBackUp newStickNoteForUser);
    }
}
