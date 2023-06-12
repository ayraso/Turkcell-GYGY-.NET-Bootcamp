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
    public class EFSubtopicRepository : ISubtopicRepository
    {
        private readonly TvrsDbContext _dbContext;

        public EFSubtopicRepository(TvrsDbContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        public void Add(Subtopic entity)
        {
            _dbContext.Subtopics.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(Subtopic entity)
        {
            await _dbContext.Subtopics.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteAll()
        {
            _dbContext.Subtopics.RemoveRange(_dbContext.Subtopics);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAllAsync()
        {
            _dbContext.Subtopics.RemoveRange(_dbContext.Subtopics);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteById(int id)
        {
            var subtopic = _dbContext.Subtopics.Find(id);
            _dbContext.Subtopics.Remove(subtopic);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var subtopic = await _dbContext.Subtopics.FindAsync(id);

            _dbContext.Subtopics.Remove(subtopic);
            await _dbContext.SaveChangesAsync();
        }

        public Subtopic? FindById(int id)
        {
            return _dbContext.Subtopics.Find(id);
        }

        public async Task<Subtopic?> FindByIdAsync(int id)
        {
            return await _dbContext.Subtopics.FindAsync(id);
        }

        public IEnumerable<Subtopic?> GetAll()
        {
            return _dbContext.Subtopics.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<Subtopic?>> GetAllAsync()
        {
            return await _dbContext.Subtopics.AsNoTracking().ToListAsync();
        }

        public IEnumerable<Subtopic> GetAllSubtopicsByMainTopic(int mainTopicId)
        {
            return _dbContext.Subtopics
                             .AsNoTracking()
                             .Where(d => d.MainTopicId == mainTopicId)
                             .ToList();
        }

        public async Task<IEnumerable<Subtopic>> GetAllSubtopicsByMainTopicIdAsync(int mainTopicId)
        {
            return await _dbContext.Subtopics
                             .AsNoTracking()
                             .Where(d => d.MainTopicId == mainTopicId)
                             .ToListAsync();
        }

        public Subtopic? GetById(int id)
        {
            return _dbContext.Subtopics.SingleOrDefault(e => e.Id == id);
        }

        public async Task<Subtopic?> GetByIdAsync(int id)
        {
            return await _dbContext.Subtopics.SingleOrDefaultAsync(e => e.Id == id);
        }

        public bool IsExists(int id)
        {
            return _dbContext.Subtopics.Any(e => e.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.Subtopics.AnyAsync(e => e.Id == id);
        }

        public void Update(Subtopic entity)
        {
            _dbContext.Subtopics.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(Subtopic entity)
        {
            _dbContext.Subtopics.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
