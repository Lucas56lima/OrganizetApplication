using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskForManySectorRepository(OrganizetContextDb context) : ITaskForManySectorRepository
    {
        private readonly OrganizetContextDb _context = context;

        public async Task<TaskForManySector> GetTaskForManySectorByTaskId(int idTaskForMany)
        {
            try
            {
                var taskForManyDb = await _context.TaskForManySectors
                            .Where(u => u.TaskId == idTaskForMany && u.IsActive == true)
                            .FirstOrDefaultAsync();

                return taskForManyDb;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<IEnumerable<TaskForManySector>> GetTaskForManySector()
        {
            try
            {
                return await _context.TaskForManySectors
                        .Where(u => u.IsActive == true)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }       

        public async Task<TaskForManySector> PostTaskForManySector(TaskForManySector taskforManySector)
        {
            try
            {
                await _context.TaskForManySectors.AddAsync(taskforManySector);
                await _context.SaveChangesAsync();
                return taskforManySector;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }

        }
    }
}
