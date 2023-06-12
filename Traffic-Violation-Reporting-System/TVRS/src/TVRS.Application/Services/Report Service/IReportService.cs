using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Requests;
using TVRS.Application.DTOs.Responses;
using TVRS.Application.Services.Common;
using TVRS.Application.Services.Report_Service;
using TVRS.Domain.Entities;

namespace TVRS.Application.Services
{
    public interface IReportService : IService<ViolationReport>, IReportValidator, IReportLogService
    {
        public void CreateNewViolationReport(NewViolationReportRequest newReport);
        public Task CreateNewViolationReportAsync(NewViolationReportRequest newReport);
        public void ChangeStatusOfViolationReport(UpdateViolationReportRequest updatedReport);
        public Task ChangeStatusOfViolationReportAsync(UpdateViolationReportRequest updatedReport);
        public IEnumerable<DisplayViolationReportResponse> GetViolationReportsByUser(int userId);
        public Task<IEnumerable<DisplayViolationReportResponse>> GetViolationReportsByUserAsync(int userId);
        public Task<IEnumerable<DisplayViolationReportResponse>> GetViolationReportsByMainTopicAsync(int mainTopicId);
        public IEnumerable<DisplayViolationReportResponse> GetViolationReportsByMainTopic(int mainTopicId);
        public Task<IEnumerable<DisplayViolationReportResponse>> GetViolationReportsBySubtopicAsync(int subtopicId);
        public IEnumerable<DisplayViolationReportResponse> GetViolationReportsBySubtopic(int subtopicId);
        public Task<IEnumerable<DisplayViolationReportResponse>> GetViolationReportsByProvinceAsync(int provinceId);
        public IEnumerable<DisplayViolationReportResponse> GetViolationReportsByProvince(int provinceId);
        public Task<IEnumerable<DisplayViolationReportResponse>> GetViolationReportsByDistrictAsync(int provinceId);
        public IEnumerable<DisplayViolationReportResponse> GetViolationReportsByDistrict(int districtId);



    }
}
