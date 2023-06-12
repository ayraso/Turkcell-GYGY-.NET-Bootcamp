using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories.Common;

namespace TVRS.Domain.Repositories
{
    public interface IReportLogRepository : IRepository<ReportLog>
    {
        public void DeleteByKey(int reportId, int statusId);
        public Task DeleteByKeyAsync(int reportId, int statusId);
        public Task<ReportLog?> GetByKeyAsync(int reportId, int statusId);
        public ReportLog? GetByKey(int reportId, int statusId);
        public Task<ReportLog?> FindByKeyAsync(int reportId, int statusId);
        public ReportLog? FindByKey(int reportId, int statusId);
        public ReportLog? GetLastestReportLogByReportId(int reportId);
        public Task<ReportLog?> GetLastestReportLogByReportIdAsync(int reportId);
    }
}
