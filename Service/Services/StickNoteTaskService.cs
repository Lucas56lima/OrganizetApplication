using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;

namespace Service.Services
{
    public class StickNoteTaskService(IStickNoteTaskRepository repository) : IStickNoteTaskService
    {
        private readonly IStickNoteTaskRepository _repository = repository;

        public async Task<IEnumerable<StickNoteTaskForMany>> GetAllStickNote()
        {
            return await _repository.GetAllStickNote();
        }

        public async Task<StickNoteTaskForMany> GetStickNoteById(int id)
        {
            var stickNoteTaskDb = await _repository.GetStickNoteById(id);
            if (stickNoteTaskDb == null)
            {
                return null;
            }
            return stickNoteTaskDb;
        }

        public async Task<IEnumerable<StickNoteViewModel>> GetStickNoteByTaskId(int taskId)
        {
            var stickNoteTaskDb = await _repository.GetStickNoteByTaskId(taskId);
            if (stickNoteTaskDb == null)
            {
                return null;
            }
            return stickNoteTaskDb;
        }       

        public async Task<IEnumerable<StickNoteViewModel>> GetStickNoteTaskForStatus(int taskId, string status)
        {
            return await _repository.GetStickNoteTaskForStatus(taskId,status);
        }

        public async Task<IEnumerable<StickNoteTaskForMany>> GetStickNoteTaskForStatusAndSector(int taskId, string status, int sectorId)
        {
           return await _repository.GetStickNoteTaskForStatusAndSector(taskId,status,sectorId);
        }

        public Task<StickNoteTaskForMany> PostStickNoteTask(StickNoteTaskForMany stickNoteTask)
        {
            if (stickNoteTask == null)
            {
                return null;
            }
            return _repository.PostStickNoteTask(stickNoteTask);
        }

        public Task<StickNoteTaskForUserBackUp> PostStickNoteTaskForUser(StickNoteTaskForUserBackUp stickNoteTaskForUser)
        {
            throw new NotImplementedException();
        }

        public async Task<StickNoteTaskForMany> PutStickNoteById(int id, StickNoteTaskForMany newStickNote)
        {
            try
            {
                StickNoteTaskForMany stickNoteTaskDb = await GetStickNoteById(id);
                if (stickNoteTaskDb == null) return null;
                newStickNote.Id = stickNoteTaskDb.Id;
                newStickNote.TaskId = stickNoteTaskDb.TaskId;
                newStickNote.SectorId = stickNoteTaskDb.SectorId;                
                return await _repository.PutStickNoteById(id, newStickNote);
            }
            catch
            {
                throw new Exception($"Erro ao atualizar o id: {id}");
            }
            
        }

        public Task<StickNoteTaskForUserBackUp> PutStickNoteByIdForUser(int sitckNoteId, StickNoteTaskForUserBackUp newStickNoteForUser)
        {
            throw new NotImplementedException();
        }
    }
}
