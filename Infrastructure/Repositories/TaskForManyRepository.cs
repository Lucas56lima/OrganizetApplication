using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskForManyRepository : ITaskForManyRepository
    {
        private readonly OrganizetContextDb _context;
        public TaskForManyRepository(OrganizetContextDb context)
        {
            _context = context;
        }

        public async Task<TaskForMany> GetTaskForManyById(int idTaskForMany)
        {
            try
            {
                var taskForManyDb = await _context.TasksForMany
                            .Where(u => u.Id == idTaskForMany && u.IsActive == true)
                            .FirstOrDefaultAsync();

                return taskForManyDb;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<TaskForMany> GetTaskForManyByTitle(string titleTaskForMany)
        {
            try
            {
                var taskForManyDb = await _context.TasksForMany
                            .Where(u => u.Title == titleTaskForMany && u.IsActive == true)
                            .FirstOrDefaultAsync();

                return taskForManyDb;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<IEnumerable<TaskForMany>> GetTasksForMany()
        {
            try
            {
                return await _context.TasksForMany
                            .Where(u => u.IsActive == true)
                            .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<TaskForMany> PostTaskForMany(TaskForMany taskforMany)
        {

            try
            {
                await _context.TasksForMany.AddAsync(taskforMany);
                await _context.SaveChangesAsync();
                return taskforMany;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }
    }
}
