using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Requests;
using TVRS.Application.DTOs.Responses;
using TVRS.Application.Services.Report_Service;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories;
using TVRS.Domain.Repositories.Common;

namespace TVRS.Application.Services
{ 
    public class ReportService : IReportService
    {
        private readonly IViolationReportRepository _reportRepository;
        private readonly IReportLogRepository _reportLogRepository;
        private readonly IMapper _mapper;

        public ReportService(IViolationReportRepository reportRepository, IReportLogRepository reportLogRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _reportLogRepository = reportLogRepository;
            _mapper = mapper;
        }

        public void AddNewReportLog(ReportLog reportLog)
        {
            _reportLogRepository.Add(reportLog);
        }

        public async Task AddNewReportLogAsync(ReportLog reportLog)
        {
            await _reportLogRepository.AddAsync(reportLog);
        }

        public void ChangeStatusOfViolationReport(UpdateViolationReportRequest updatedReportRequest)
        {
            var existingReport = _reportRepository.FindByIdAsync(updatedReportRequest.Id);
            if (existingReport != null)
            {
                var updatedReportEntity = _mapper.Map<ViolationReport>(updatedReportRequest);
                _reportRepository.Update(updatedReportEntity);

                var newReportLog = _mapper.Map<ReportLog>(updatedReportEntity);
                this.AddNewReportLog(newReportLog);

            }
        }

        public async Task ChangeStatusOfViolationReportAsync(UpdateViolationReportRequest updatedReportRequest)
        {
            var existingReport = await _reportRepository.FindByIdAsync(updatedReportRequest.Id);
            if (existingReport != null)
            {
                var updatedReportEntity = _mapper.Map<ViolationReport>(updatedReportRequest);
                await _reportRepository.UpdateAsync(updatedReportEntity);

                var newReportLog = _mapper.Map<ReportLog>(updatedReportEntity);
                await this.AddNewReportLogAsync(newReportLog);
            }
        }

        public async Task CreateNewViolationReportAsync(NewViolationReportRequest newReport)
        {
            var violationReportEntity = _mapper.Map<ViolationReport>(newReport);
            await _reportRepository.AddAsync(violationReportEntity);

            var reportLogEntity = _mapper.Map<ReportLog>(violationReportEntity);
            await _reportLogRepository.AddAsync(reportLogEntity);
        }

        public void CreateNewViolationReport(NewViolationReportRequest newReport)
        {
            var violationReportEntity = _mapper.Map<ViolationReport>(newReport);
            _reportRepository.AddAsync(violationReportEntity);

            var reportLogEntity = _mapper.Map<ReportLog>(violationReportEntity);
            _reportLogRepository.AddAsync(reportLogEntity);
        }

        public void DeleteReportLog(int reportId, int statusId)
        {
            _reportLogRepository.DeleteByKey(reportId, statusId);
        }

        public async Task DeleteReportLogAsync(int reportId, int statusId)
        {
            await _reportLogRepository.DeleteByKeyAsync(reportId, statusId);
        }

        public Task<IEnumerable<ReportLog?>> GetReportLogsAsyncByReportId(int reportId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportLog?> GetReportLogsByReportId(int reportId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DisplayViolationReportResponse> GetViolationReportsByUser(int userId)
        {
            var violationReports = _reportRepository.GetViolationReportsByUser(userId);
            return _mapper.Map<IEnumerable<DisplayViolationReportResponse>>(violationReports);
        }

        public async Task<IEnumerable<DisplayViolationReportResponse>> GetViolationReportsByUserAsync(int userId)
        {
            var violationReports = await _reportRepository.GetViolationReportsByUserAsync(userId);
            var displayViolationReports = _mapper.Map<IEnumerable<DisplayViolationReportResponse>>(violationReports);

            foreach (var report in displayViolationReports)
            {
                var latestLog = await this.GetLastestReportLogByReportIdAsync(report.Id);
                report.InvestigationStatusName = latestLog?.Note;
            }

            return displayViolationReports;
        }

        public IEnumerable<DisplayViolationReportResponse> GetViolationReportsByDistrict(int districtId)
        {
            var violationReports = _reportRepository.GetViolationReportsByDistrict(districtId);
            return _mapper.Map<IEnumerable<DisplayViolationReportResponse>>(violationReports);
        }

        public async Task<IEnumerable<DisplayViolationReportResponse>> GetViolationReportsByDistrictAsync(int districtId)
        {
            var violationReports = await _reportRepository.GetViolationReportsByDistrictAsync(districtId);
            return _mapper.Map<IEnumerable<DisplayViolationReportResponse>>(violationReports);
        }

        public IEnumerable<DisplayViolationReportResponse> GetViolationReportsByMainTopic(int mainTopicId)
        {
            var violationReports = _reportRepository.GetViolationReportsByMainTopic(mainTopicId);
            return _mapper.Map<IEnumerable<DisplayViolationReportResponse>>(violationReports);
        }

        public async Task<IEnumerable<DisplayViolationReportResponse>> GetViolationReportsByMainTopicAsync(int mainTopicId)
        {
            var violationReports = await _reportRepository.GetViolationReportsByMainTopicAsync(mainTopicId);
            return _mapper.Map<IEnumerable<DisplayViolationReportResponse>>(violationReports);
        }

        public IEnumerable<DisplayViolationReportResponse> GetViolationReportsByProvince(int provinceId)
        {
            var violationReports = _reportRepository.GetViolationReportsByProvince(provinceId);
            return _mapper.Map<IEnumerable<DisplayViolationReportResponse>>(violationReports);
        }

        public async Task<IEnumerable<DisplayViolationReportResponse>> GetViolationReportsByProvinceAsync(int provinceId)
        {
            var violationReports = await _reportRepository.GetViolationReportsByProvinceAsync(provinceId);
            return _mapper.Map<IEnumerable<DisplayViolationReportResponse>>(violationReports);
        }

        public IEnumerable<DisplayViolationReportResponse> GetViolationReportsBySubtopic(int subtopicId)
        {
            var violationReports = _reportRepository.GetViolationReportsBySubtopic(subtopicId);
            return _mapper.Map<IEnumerable<DisplayViolationReportResponse>>(violationReports);
        }

        public async Task<IEnumerable<DisplayViolationReportResponse>> GetViolationReportsBySubtopicAsync(int subtopicId)
        {
            var violationReports = await _reportRepository.GetViolationReportsBySubtopicAsync(subtopicId);
            return _mapper.Map<IEnumerable<DisplayViolationReportResponse>>(violationReports);
        }

        public ReportLog? GetLastestReportLogByReportId(int reportId)
        {
            var reportLog = _reportLogRepository.GetLastestReportLogByReportId(reportId);
            return reportLog;
        }
        public async Task<ReportLog?> GetLastestReportLogByReportIdAsync(int reportId)
        {
            var reportLog = await _reportLogRepository.GetLastestReportLogByReportIdAsync(reportId);
            return reportLog;
        }


    }
}
