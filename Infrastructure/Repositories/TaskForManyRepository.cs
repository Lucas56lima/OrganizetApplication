using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskForManyRepository(OrganizetContextDbLocal context,OrganizetContextDbServer contextServer) : ITaskForManyRepository
    {
        private readonly OrganizetContextDbLocal _context = context;
        private readonly OrganizetContextDbServer _contextServer = contextServer;
        public async Task<TaskForMany> GetTaskForManyById(int idTaskForMany)
        {
            try
            {
                var taskForManyDb = await _context.TasksForMany.AsNoTracking()
                             .Where(u => u.Id == idTaskForMany && u.IsActive == true)
                             .FirstOrDefaultAsync();

                return taskForManyDb;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco",ex);
            }
        }


        public Task<TaskForMany> GetTaskForManyByTitle(string titleTaskForMany)
        {
            //try
            //{
            //    var taskForManyDb = await _context.TasksForMany
            //                .Where(u => u.Title == titleTaskForMany && u.IsActive == true)
            //                .FirstOrDefaultAsync();

            //    return taskForManyDb;
            //}
            //catch (Exception ex)
            //{
                throw new Exception("Erro ao acessar o banco");
            //}
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
                await _contextServer.TasksForMany.AddAsync(taskforMany);
                await _contextServer.SaveChangesAsync();
                return taskforMany;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<TaskForMany> PutTaskForManyByIdAndSector(int id, TaskForMany taskForMany)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Apenas chama a leitura sem envolver outra operação que possa causar loop
                var taskForManyDb = await GetTaskForManyById(id);

                if (taskForManyDb == null)
                {
                    throw new Exception("Task not found");
                }

                _context.Entry(taskForManyDb).CurrentValues.SetValues(taskForMany);
                _context.Entry(taskForManyDb).State = EntityState.Modified;
                _contextServer.Entry(taskForManyDb).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await _contextServer.SaveChangesAsync();
                // Se não há mais operações que possam gerar um loop, confirme a transação
                await transaction.CommitAsync();

                return taskForManyDb;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Erro ao atualizar a tarefa", ex);
            }
        }

    }
}
