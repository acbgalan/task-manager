using Microsoft.EntityFrameworkCore;
using task_manager.data.Models;
using task_manager.data.Repositories.Interface;

namespace task_manager.data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddAsync(Category entity)
        {
            await _context.AddAsync(entity);
        }

        public async System.Threading.Tasks.Task<Category> GetAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
        public System.Threading.Tasks.Task<Category> GetAsync(string id)
        {
            throw new NotImplementedException("This method is not supported");
        }

        public async System.Threading.Tasks.Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(Category entity)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                _context.Categories.Update(entity);
            });
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            Category category = await this.GetAsync(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
            }
        }

        public System.Threading.Tasks.Task DeleteAsync(string id)
        {
            throw new NotImplementedException("This method is not supported");
        }

        public async System.Threading.Tasks.Task DeleteAsync(Category entity)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                _context.Categories.Remove(entity);
            });
        }

        public async System.Threading.Tasks.Task<bool> ExitsAsync(int id)
        {
            return await _context.Categories.AnyAsync(x => x.Id == id);
        }

        public System.Threading.Tasks.Task<bool> ExitsAsync(string id)
        {
            throw new NotImplementedException("This method is not supported");
        }

        public async System.Threading.Tasks.Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
