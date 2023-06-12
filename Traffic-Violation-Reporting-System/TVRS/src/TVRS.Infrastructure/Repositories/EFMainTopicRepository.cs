using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories;
using TVRS.Infrastructure.Data_Context;

namespace TVRS.Infrastructure.Repositories
{
    public class EFMainTopicRepository : IMainTopicRepository
    {
        private readonly TvrsDbContext _dbContext;

        public EFMainTopicRepository(TvrsDbContext dbContext) 
        {
            this._dbContext = dbContext;

        }

        public void Add(MainTopic entity)
        {
            _dbContext.MainTopics.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(MainTopic entity)
        {
            await _dbContext.MainTopics.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteAll()
        {
            _dbContext.MainTopics.RemoveRange(_dbContext.MainTopics);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAllAsync()
        {
            _dbContext.MainTopics.RemoveRange(_dbContext.MainTopics);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteById(int id)
        {
            var maintopic = _dbContext.MainTopics.Find(id);
            _dbContext.MainTopics.Remove(maintopic);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var maintopic = await _dbContext.MainTopics.FindAsync(id);

            _dbContext.MainTopics.Remove(maintopic);
            await _dbContext.SaveChangesAsync();
        }

        public MainTopic? FindById(int id)
        {
            return _dbContext.MainTopics.Find(id);
        }

        public async Task<MainTopic?> FindByIdAsync(int id)
        {
            return await _dbContext.MainTopics.FindAsync(id);
        }

        public IEnumerable<MainTopic?> GetAll()
        {
            return _dbContext.MainTopics.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<MainTopic?>> GetAllAsync()
        {
            return await _dbContext.MainTopics.AsNoTracking().ToListAsync();
        }

        public MainTopic? GetById(int id)
        {
            return _dbContext.MainTopics.SingleOrDefault(e => e.Id == id);
        }

        public async Task<MainTopic?> GetByIdAsync(int id)
        {
            return await _dbContext.MainTopics.SingleOrDefaultAsync(e => e.Id == id);
        }

        public bool IsExists(int id)
        {
            return _dbContext.MainTopics.Any(e => e.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.MainTopics.AnyAsync(e => e.Id == id);
        }

        public void Update(MainTopic entity)
        {
            _dbContext.MainTopics.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(MainTopic entity)
        {
            _dbContext.MainTopics.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
