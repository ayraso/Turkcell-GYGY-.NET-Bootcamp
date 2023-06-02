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
        public async Task<List<CategoryItem>> GetAllAsync()
        {
            return await _context.CategoryItems.ToListAsync();
        }

        public async Task<CategoryItem> GetByIdAsync(int id)
        {
            return await _context.CategoryItems.FindAsync(id);
        }
    }
}
