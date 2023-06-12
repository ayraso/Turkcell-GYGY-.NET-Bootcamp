using Microsoft.EntityFrameworkCore;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories;
using TVRS.Infrastructure.Data_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVRS.Infrastructure.Repositories
{
    public class EFViolationReportRepository : IViolationReportRepository
    {
        private readonly TvrsDbContext _dbContext;

        public EFViolationReportRepository(TvrsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(ViolationReport entity)
        {
            _dbContext.Set<ViolationReport>()
                      .Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(ViolationReport entity)
        {
            await _dbContext.Set<ViolationReport>()
                            .AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteAll()
        {
            _dbContext.Set<ViolationReport>()
                      .RemoveRange(_dbContext.Set<ViolationReport>());
            _dbContext.SaveChanges();
        }

        public async Task DeleteAllAsync()
        {
            _dbContext.Set<ViolationReport>()
                      .RemoveRange(_dbContext.Set<ViolationReport>());
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteById(int id)
        {
            var entity = _dbContext.Set<ViolationReport>()
                                   .Find(id);
            
            _dbContext.Set<ViolationReport>()
                        .Remove(entity);
            _dbContext.SaveChanges();
            
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _dbContext.Set<ViolationReport>()
                                    .FindAsync(id);
            
            _dbContext.Set<ViolationReport>()
                        .Remove(entity);
            await _dbContext.SaveChangesAsync();
            
        }

        public ViolationReport? FindById(int id)
        {
            return _dbContext.Set<ViolationReport>()
                             .Find(id);
        }

        public async Task<ViolationReport?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<ViolationReport>()
                                   .FindAsync(id);
        }

        public IEnumerable<ViolationReport?> GetAll()
        {
            return _dbContext.Set<ViolationReport>()
                             .AsNoTracking()
                             .Include(e => e.District)
                             .Include(e => e.Subtopic)
                             .Include(e => e.ReportLogs)
                             .ToList();
        }

        public async Task<IEnumerable<ViolationReport?>> GetAllAsync()
        {
            return await _dbContext.Set<ViolationReport>()
                                   .AsNoTracking()
                                   .Include(e => e.District)
                                   .Include(e => e.Subtopic)
                                   .Include(e => e.ReportLogs)
                                   .ToListAsync();
        }

        public ViolationReport? GetById(int id)
        {
            return _dbContext.Set<ViolationReport>()
                             .Include(e => e.District)
                             .Include(e => e.Subtopic)
                             .Include(e => e.ReportLogs)
                             .SingleOrDefault(e => e.Id == id);
        }

        public async Task<ViolationReport?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<ViolationReport>()
                                   .AsNoTracking()
                                   .Include(e => e.District)
                                   .Include(e => e.Subtopic)
                                   .Include(e => e.ReportLogs)
                                   .SingleOrDefaultAsync(e => e.Id == id);
        }

        public IEnumerable<ViolationReport?> GetViolationReportsByDate(DateTime date)
        {
            return _dbContext.Set<ViolationReport>()
                             .AsNoTracking()
                             .Where(e => e.IncidentDateTime.Date == date)
                             .Include(e => e.District)
                             .Include(e => e.Subtopic)
                             .Include(e => e.ReportLogs)
                             .ToList();
        }

        public async Task<IEnumerable<ViolationReport?>> GetViolationReportsByDateAsync(DateTime date)
        {
            return await _dbContext.Set<ViolationReport>()
                                   .AsNoTracking()
                                   .Where(e => e.IncidentDateTime.Date == date)
                                   .Include(e => e.District)
                                   .Include(e => e.Subtopic)
                                   .Include(e => e.ReportLogs)
                                   .ToListAsync();
        }

        public IEnumerable<ViolationReport?> GetViolationReportsByDistrict(int districtId)
        {
            return _dbContext.Set<ViolationReport>()
                             .AsNoTracking()
                             .Where(e => e.DistrictId == districtId)
                             .Include(e => e.District)
                             .Include(e => e.Subtopic)
                             .Include(e => e.ReportLogs)
                             .ToList();
        }

        public async Task<IEnumerable<ViolationReport?>> GetViolationReportsByDistrictAsync(int districtId)
        {
            return await _dbContext.Set<ViolationReport>()
                                   .AsNoTracking()
                                   .Where(e => e.DistrictId == districtId)
                                   .Include(e => e.District)
                                   .Include(e => e.Subtopic)
                                   .Include(e => e.ReportLogs)
                                   .ToListAsync();
        }

        public IEnumerable<ViolationReport?> GetViolationReportsByMainTopic(int topicId)
        {
            return _dbContext.Set<ViolationReport>()
                             .AsNoTracking()
                             .Where(e => e.Subtopic.MainTopicId == topicId)
                             .Include(e => e.District)
                             .Include(e => e.Subtopic)
                             .Include(e => e.ReportLogs)
                             .ToList();
        }

        public async Task<IEnumerable<ViolationReport?>> GetViolationReportsByMainTopicAsync(int topicId)
        {
            return await _dbContext.Set<ViolationReport>()
                                   .AsNoTracking() 
                                   .Where(e => e.Subtopic.MainTopicId == topicId)
                                   .Include(e => e.District)
                                   .Include(e => e.Subtopic)
                                   .Include(e => e.ReportLogs)
                                   .ToListAsync();
        }

        public IEnumerable<ViolationReport?> GetViolationReportsByProvince(int provinceId)
        {
            return _dbContext.Set<ViolationReport>()
                             .AsNoTracking()
                             .Where(e => e.District.ProvinceId == provinceId)
                             .Include(e => e.District)
                             .Include(e => e.Subtopic)
                             .Include(e => e.ReportLogs)
                             .ToList();
        }

        public async Task<IEnumerable<ViolationReport?>> GetViolationReportsByProvinceAsync(int provinceId)
        {
            return await _dbContext.Set<ViolationReport>()
                                   .AsNoTracking()
                                   .Where(e => e.District.ProvinceId == provinceId)
                                   .Include(e => e.District)
                                   .Include(e => e.Subtopic)
                                   .Include(e => e.ReportLogs)
                                   .ToListAsync();
        }

        public IEnumerable<ViolationReport?> GetViolationReportsBySubtopic(int topicId)
        {
            return _dbContext.Set<ViolationReport>()
                             .AsNoTracking()
                             .Where(e => e.SubtopicId == topicId)
                             .Include(e => e.District)
                             .Include(e => e.Subtopic)
                             .Include(e => e.ReportLogs)
                             .ToList();
        }

        public async Task<IEnumerable<ViolationReport?>> GetViolationReportsBySubtopicAsync(int topicId)
        {
            return await _dbContext.Set<ViolationReport>()
                                   .AsNoTracking()
                                   .Where(e => e.SubtopicId == topicId)
                                   .Include(e => e.District)
                                   .Include(e => e.Subtopic)
                                   .Include(e => e.ReportLogs)
                                   .ToListAsync();
        }

        public IEnumerable<ViolationReport?> GetViolationReportsByUser(int userId)
        {
            return _dbContext.Set<ViolationReport>()
                             .AsNoTracking()
                             .Where(e => e.UserId == userId)
                             .Include(e => e.District)
                             .Include(e => e.Subtopic)
                             .Include(e => e.ReportLogs)
                             .ToList();
        }

        public async Task<IEnumerable<ViolationReport?>> GetViolationReportsByUserAsync(int userId)
        {
            return await _dbContext.Set<ViolationReport>()
                                   .AsNoTracking()
                                   .Where(e => e.UserId == userId)
                                   .Include(e => e.District)
                                   .Include(e => e.Subtopic)
                                   .Include(e => e.ReportLogs)
                                   .ToListAsync();
        }

        public bool IsExists(int id)
        {
            return _dbContext.ViolationReports.Any(e => e.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.ViolationReports.AnyAsync(e => e.Id == id);
        }

        public void Update(ViolationReport entity)
        {
            _dbContext.ViolationReports.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(ViolationReport entity)
        {
            _dbContext.ViolationReports.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}