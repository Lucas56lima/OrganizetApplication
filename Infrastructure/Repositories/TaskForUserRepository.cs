using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskForUserRepository(OrganizetContextDb context) : ITaskForUserRepository
    {
        private readonly OrganizetContextDb _context = context;

        public async Task<TaskForUser> GetTaskForUserById(int idTaskForUser)
        {
            try
            {
                var taskForManyDb = await _context.TasksForUsers
                            .Where(u => u.Id == idTaskForUser && u.IsActive == true)
                            .FirstOrDefaultAsync();

                return taskForManyDb;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<TaskForUser> GetTaskForUserByTitle(string titleTaskForTitle)
        {
            try
            {
                var taskForManyDb = await _context.TasksForUsers
                            .Where(u => u.Title == titleTaskForTitle && u.IsActive == true)
                            .FirstOrDefaultAsync();

                return taskForManyDb;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<IEnumerable<TaskForUser>> GetTasksForUser()
        {
            try
            {
                return await _context.TasksForUsers
                            .Where(u => u.IsActive == true)
                            .ToListAsync();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<TaskForUser> PostTaskForUser(TaskForUser taskforUser)
        {
            try
            {
                await _context.TasksForUsers.AddAsync(taskforUser);
                await _context.SaveChangesAsync();
                return taskforUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }
    }
}
