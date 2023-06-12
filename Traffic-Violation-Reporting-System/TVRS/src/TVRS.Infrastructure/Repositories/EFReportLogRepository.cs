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
    public class EFReportLogRepository : IReportLogRepository
    {
        private readonly TvrsDbContext _dbContext;

        public EFReportLogRepository(TvrsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(ReportLog entity)
        {
            _dbContext.ReportLogs.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(ReportLog entity)
        {
            await _dbContext.ReportLogs.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteAll()
        {
            _dbContext.ReportLogs.RemoveRange(_dbContext.ReportLogs);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAllAsync()
        {
            _dbContext.ReportLogs.RemoveRange(_dbContext.ReportLogs);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteByKey(int reportId, int statusId)
        {
            var reportLog = _dbContext.ReportLogs.Find(reportId, statusId);
            _dbContext.ReportLogs.Remove(reportLog);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByKeyAsync(int reportId, int statusId)
        {
            var reportLog = await _dbContext.ReportLogs.FindAsync(reportId, statusId);
            _dbContext.ReportLogs.Remove(reportLog);
            await _dbContext.SaveChangesAsync();
        }

        public ReportLog? FindByKey(int reportId, int statusId)
        {
            return _dbContext.ReportLogs.Find(reportId, statusId);
        }

        public async Task<ReportLog?> FindByKeyAsync(int reportId, int statusId)
        {
            return await _dbContext.ReportLogs.FindAsync(reportId, statusId);
        }

        public IEnumerable<ReportLog?> GetAll()
        {
            return _dbContext.ReportLogs.AsNoTracking()
                                        .ToList();
        }

        public async Task<IEnumerable<ReportLog?>> GetAllAsync()
        {
            return await _dbContext.ReportLogs.AsNoTracking()
                                              .ToListAsync();
        }

        public ReportLog? GetByKey(int reportId, int statusId)
        {
            return _dbContext.ReportLogs.AsNoTracking()
                                        .SingleOrDefault(r => r.ReportId == reportId && r.StatusId == statusId);
        }

        public async Task<ReportLog?> GetByKeyAsync(int reportId, int statusId)
        {
            return await _dbContext.ReportLogs.AsNoTracking()
                                               .SingleOrDefaultAsync(r => r.ReportId == reportId && r.StatusId == statusId);
        }

        public IEnumerable<ReportLog?> GetReportLogsByReportId(int reportId)
        {
            return _dbContext.ReportLogs.Where(r => r.ReportId == reportId)
                                        .AsNoTracking()
                                        .ToList();
        }

        public async Task<IEnumerable<ReportLog?>> GetReportLogsAsyncByReportId(int reportId)
        {
            return await _dbContext.ReportLogs.Where(r => r.ReportId == reportId)
                                              .AsNoTracking()
                                              .ToListAsync();
        }

        public void Update(ReportLog entity)
        {
            _dbContext.ReportLogs.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(ReportLog entity)
        {
            _dbContext.ReportLogs.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public bool IsExists(int id)
        {
            return _dbContext.ReportLogs.Any(e => e.ReportId == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.ReportLogs.AnyAsync(e => e.ReportId == id);
        }

        public ReportLog? GetLastestReportLogByReportId(int reportId)
        {
            return _dbContext.ReportLogs.Where(log => log.ReportId == reportId)
                                        .OrderByDescending(log => log.DateTime)
                                        .FirstOrDefault();
        }

        public async Task<ReportLog?> GetLastestReportLogByReportIdAsync(int reportId)
        {
            return await  _dbContext.ReportLogs.Where(log => log.ReportId == reportId)
                                               .OrderByDescending(log => log.DateTime)
                                               .FirstOrDefaultAsync();
        }
    }
}
