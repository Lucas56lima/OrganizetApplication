using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StickNoteTaskRepository(OrganizetContextDbLocal context, OrganizetContextDbServer contextServer) : IStickNoteTaskRepository
    {
        private readonly OrganizetContextDbLocal _context = context;
        private readonly OrganizetContextDbServer _contextServer = contextServer;

        public async Task<IEnumerable<StickNoteTaskForMany>> GetAllStickNote()
        {
            try
            {
                return await _contextServer.SticksNotesTasksForMany
                            .Where(u => u.IsActive == true)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<StickNoteTaskForMany> GetStickNoteById(int id)
        {
            try
            {
                var stickNotesTask = await _contextServer.SticksNotesTasksForMany
                            .Where(u => u.Id == id && u.IsActive == true)
                            .FirstOrDefaultAsync();

                return stickNotesTask;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<IEnumerable<StickNoteViewModel>> GetStickNoteByTaskId(int taskId)
        {
            try
            {
                return await _contextServer.SticksNotesTasksForMany
                            .Join(_contextServer.Sectors,
                            stickNotes => stickNotes.SectorId,
                            sectors => sectors.Id,
                            (stickNotes, sectors) => new StickNoteViewModel
                            {
                                Id = stickNotes.Id,
                                Content = stickNotes.Content,
                                TaskId = stickNotes.TaskId,
                                SectorId = stickNotes.SectorId,
                                Sector = sectors.Name,
                                Color = sectors.Color,
                                Status = stickNotes.Status,
                                IsActive = stickNotes.IsActive
                            })
                            .Where(u => u.TaskId == taskId && u.IsActive == true)
                            .ToListAsync();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<StickNoteTaskForMany> GetStickNoteTaskForStatus(string status)
        {
            try
            {
                var stickNotesTask = await _contextServer.SticksNotesTasksForMany
                            .Where(u => u.Status == status && u.IsActive == true)
                            .FirstOrDefaultAsync();

                return stickNotesTask;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<IEnumerable<StickNoteViewModel>> GetStickNoteTaskForStatus(int taskId, string status)
        {
            try
            {
                return await _contextServer.SticksNotesTasksForMany
                            .Join(_contextServer.Sectors,
                            stickNotes => stickNotes.SectorId,
                            sectors => sectors.Id,
                            (stickNotes, sectors) => new StickNoteViewModel
                            {
                                Id = stickNotes.Id,
                                Content = stickNotes.Content,
                                TaskId = stickNotes.TaskId,
                                SectorId = stickNotes.SectorId,
                                Sector = sectors.Name,
                                Color = sectors.Color,
                                Status = stickNotes.Status,
                                IsActive = stickNotes.IsActive
                            })
                            .Where(u => u.TaskId == taskId && u.Status == status && u.IsActive == true)
                            .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<IEnumerable<StickNoteTaskForMany>> GetStickNoteTaskForStatusAndSector(int taskId, string status, int sectorId)
        {
            try
            {
                return await _context.SticksNotesTasksForMany
                            .Where(u => u.IsActive == true && u.TaskId == taskId && u.Status == status && u.SectorId == sectorId)
                            .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<StickNoteTaskForMany> PostStickNoteTask(StickNoteTaskForMany stickNoteTask)
        {
            try
            {
                await _contextServer.SticksNotesTasksForMany.AddAsync(stickNoteTask);
                await _contextServer.SaveChangesAsync();

                return stickNoteTask;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<StickNoteTaskForUserBackUp> PostStickNoteTaskForUser(StickNoteTaskForUserBackUp stickNoteTaskForUser)
        {
            try
            {                
                await _contextServer.StickNotesTasksForUsers.AddAsync(stickNoteTaskForUser);
                await _contextServer.SaveChangesAsync();
                return stickNoteTaskForUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<StickNoteTaskForMany> PutStickNoteById(int id, StickNoteTaskForMany newStickNote)
        {
            try
            { 
                var stickNoteTaskDb = await GetStickNoteById(id);
                _context.Entry(stickNoteTaskDb).CurrentValues.SetValues(newStickNote);
                _context.Entry(stickNoteTaskDb).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _contextServer.Entry(stickNoteTaskDb).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await _contextServer.SaveChangesAsync();
                return stickNoteTaskDb;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }

        }

        public async Task<StickNoteTaskForUserBackUp> PutStickNoteByIdForUser(int sitckNoteId, StickNoteTaskForUserBackUp newStickNoteForUser)
        {
            try
            {
                var stickNoteTaskDb = await GetStickNoteById(sitckNoteId);
                
                _context.Entry(stickNoteTaskDb).CurrentValues.SetValues(newStickNoteForUser);
                _context.Entry(stickNoteTaskDb).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _contextServer.Entry(stickNoteTaskDb).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await _contextServer.SaveChangesAsync();
                return newStickNoteForUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }
    }
}
