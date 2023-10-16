using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_manager.data.Models;
using task_manager.data.Repositories.Interface;

namespace task_manager.data.Repositories
{
    public class StepRepository : IStepRepository
    {
        private readonly ApplicationDBContext _context;

        public StepRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddAsync(Step entity)
        {
            await _context.AddAsync(entity);
        }

        public async System.Threading.Tasks.Task<Step> GetAsync(int id)
        {
            return await _context.Steps.FindAsync(id);
        }

        public async System.Threading.Tasks.Task<Step> GetAsync(string id)
        {
            throw new NotImplementedException("This method is not supported");
        }

        public async System.Threading.Tasks.Task<List<Step>> GetAllAsync()
        {
            return await _context.Steps.ToListAsync();
        }

        public async Task<List<Step>> GetAllSteps(string taskId)
        {
            return await _context.Steps.Where(x => x.TaskId == new Guid(taskId)).ToListAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(Step entity)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                _context.Steps.Update(entity);
            });
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            Step step = await this.GetAsync(id);

            if (step != null)
            {
                _context.Steps.Remove(step);
            }
        }

        public async System.Threading.Tasks.Task DeleteAsync(string id)
        {
            throw new NotImplementedException("This method is not supported");
        }

        public async System.Threading.Tasks.Task DeleteAsync(Step entity)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                _context.Steps.Remove(entity);
            });
        }

        public async System.Threading.Tasks.Task<bool> ExitsAsync(int id)
        {
            return await _context.Steps.AnyAsync(x => x.Id == id);
        }

        public async System.Threading.Tasks.Task<bool> ExitsAsync(string id)
        {
            throw new NotImplementedException("This method is not supported");
        }


        public async System.Threading.Tasks.Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
