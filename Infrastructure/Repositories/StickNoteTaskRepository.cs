using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StickNoteTaskRepository(OrganizetContextDb context) : IStickNoteTaskRepository
    {
        private readonly OrganizetContextDb _context = context;

        public async Task<IEnumerable<StickNoteTask>> GetAllStickNote()
        {
            try
            {
                return await _context.StickNoteTasks
                            .Where(u => u.IsActive == true)
                            .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<StickNoteTask> GetStickNoteById(int id)
        {
            try
            {
                var stickNotesTask = await _context.StickNoteTasks
                            .Where(u => u.Id == id && u.IsActive == true)
                            .FirstOrDefaultAsync();

                return stickNotesTask;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<StickNoteTask> GetStickNoteByTaskId(int taskId)
        {
            try
            {
                var stickNotesTask = await _context.StickNoteTasks
                            .Where(u => u.TaskId == taskId && u.IsActive == true)
                            .FirstOrDefaultAsync();

                return stickNotesTask;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<StickNoteTask> GetStickNoteTaskForStatus(string status)
        {
            try
            {
                var stickNotesTask = await _context.StickNoteTasks
                            .Where(u => u.Status == status && u.IsActive == true)
                            .FirstOrDefaultAsync();

                return stickNotesTask;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<StickNoteTask> PostStickNoteTask(StickNoteTask stickNoteTask)
        {
            try
            {
                await _context.StickNoteTasks.AddAsync(stickNoteTask);
                await _context.SaveChangesAsync();
                return stickNoteTask;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }

        }

        public async Task<StickNoteTask> PutStickNoteById(int id, StickNoteTask newStickNote)
        {
            try
            {
                var stickNoteTaskDb = await GetStickNoteById(id);
                _context.Entry(stickNoteTaskDb).CurrentValues.SetValues(newStickNote);
                _context.Entry(stickNoteTaskDb).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return stickNoteTaskDb;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }

        }
    }
}
