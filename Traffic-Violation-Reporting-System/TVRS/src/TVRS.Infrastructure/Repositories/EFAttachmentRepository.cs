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
    public class EFAttachmentRepository : IAttachmentRepository
    {
        private readonly TvrsDbContext _dbContext;

        public EFAttachmentRepository(TvrsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(Attachment entity)
        {
            _dbContext.Set<Attachment>()
                       .Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(Attachment entity)
        {
            await _dbContext.Set<Attachment>()
                            .AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteAll()
        {
            _dbContext.Set<Attachment>()
                       .RemoveRange(_dbContext.Set<Attachment>());
            _dbContext.SaveChanges();
        }

        public async Task DeleteAllAsync()
        {
            _dbContext.Set<Attachment>()
                      .RemoveRange(_dbContext.Set<Attachment>());
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteById(int id)
        {
            var entity = _dbContext.Set<Attachment>()
                                   .Find(id);
            
            _dbContext.Set<Attachment>()
                        .Remove(entity);
            _dbContext.SaveChanges();
            
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _dbContext.Set<Attachment>()
                                         .FindAsync(id);
            
            _dbContext.Set<Attachment>()
                        .Remove(entity);
            await _dbContext.SaveChangesAsync();
            
        }

        public Attachment? FindById(int id)
        {
            return _dbContext.Set<Attachment>()
                             .Find(id);
        }

        public async Task<Attachment?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Attachment>()
                                   .FindAsync(id);

        }

        public IEnumerable<Attachment?> GetAll()
        {
            return _dbContext.Set<Attachment>()
                             .AsNoTracking()
                             .ToList();
        }

        public async Task<IEnumerable<Attachment?>> GetAllAsync()
        {
            return await _dbContext.Set<Attachment>()
                                   .AsNoTracking()
                                   .ToListAsync();
        }

        public IEnumerable<Attachment?> GetAttachmentsByReportId(int reportId)
        {
            return _dbContext.Set<Attachment>()
                             .AsNoTracking()
                             .Where(a => a.ReportId == reportId)
                             .ToList();
        }

        public async Task<IEnumerable<Attachment?>> GetAttachmentsByReportIdAsync(int reportId)
        {
            return await _dbContext.Set<Attachment>()
                                   .AsNoTracking()
                                   .Where(a => a.ReportId == reportId)
                                   .ToListAsync();
        }

        public Attachment? GetById(int id)
        {
            return _dbContext.Set<Attachment>()
                             .SingleOrDefault(e => e.Id == id);
        }

        public async Task<Attachment?> GetByIdAsync(int id)
        {
            return await _dbContext.Attachments
                                   .SingleOrDefaultAsync(e => e.Id == id);

        }

        public bool IsExists(int id)
        {
            return _dbContext.Attachments.Any(e => e.ReportId == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.Attachments.AnyAsync(e => e.ReportId == id);
        }

        public void Update(Attachment entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(Attachment entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
