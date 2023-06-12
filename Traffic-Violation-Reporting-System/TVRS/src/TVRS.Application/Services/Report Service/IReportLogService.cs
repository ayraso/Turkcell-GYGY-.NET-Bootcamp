using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories;

namespace TVRS.Application.Services.Report_Service
{
    public interface IReportLogService
    {
        public Task<IEnumerable<ReportLog?>> GetReportLogsAsyncByReportId(int reportId);
        public IEnumerable<ReportLog?> GetReportLogsByReportId(int reportId);
        public void AddNewReportLog(ReportLog reportLog);
        public Task AddNewReportLogAsync(ReportLog reportLog);
        public void DeleteReportLog(int reportId, int statusId);
        public Task DeleteReportLogAsync(int reportId, int statusId);
        public Task<ReportLog?> GetLastestReportLogByReportIdAsync(int reportId);
        public ReportLog? GetLastestReportLogByReportId(int reportId);

    }
}
