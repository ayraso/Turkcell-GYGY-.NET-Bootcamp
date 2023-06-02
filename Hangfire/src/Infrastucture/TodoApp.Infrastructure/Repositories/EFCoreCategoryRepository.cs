using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Repositories
{
    public class EFCoreCategoryRepository : ICategoryRepository
    {
        private readonly TodoDbContext _context;

        public EFCoreCategoryRepository(TodoDbContext context)
        {
            _context = context;

        }

        public async Task AddItemAsync(CategoryItem item)
        {
            _context.CategoryItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await _context.CategoryItems.FindAsync(id);
            if (item != null)
            {
                _context.CategoryItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CategoryItem>> GetAllAsync()
        {
            return await _context.CategoryItems.ToListAsync();
        }

        public async Task<CategoryItem> GetByIdAsync(int id)
        {
            return await _context.CategoryItems.FindAsync(id);
        }

        public async Task UpdateItemAsync(CategoryItem item)
        {
            _context.CategoryItems.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
