using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories.Common;

namespace TVRS.Domain.Repositories
{
    public interface IViolationReportRepository : IRepository<ViolationReport>
    {
        public Task DeleteByIdAsync(int id);
        public void DeleteById(int id);
        public Task<ViolationReport?> GetByIdAsync(int id);
        public ViolationReport? GetById(int id);
        public Task<ViolationReport?> FindByIdAsync(int id);
        public ViolationReport? FindById(int id);
        public Task<IEnumerable<ViolationReport?>> GetViolationReportsByUserAsync(int userId);
        public IEnumerable<ViolationReport?> GetViolationReportsByUser(int userId);
        public Task<IEnumerable<ViolationReport?>> GetViolationReportsByDateAsync(DateTime date);
        public IEnumerable<ViolationReport?> GetViolationReportsByDate(DateTime date);
        public Task<IEnumerable<ViolationReport?>> GetViolationReportsByMainTopicAsync(int topicId);
        public IEnumerable<ViolationReport?> GetViolationReportsByMainTopic(int topicId);
        public Task<IEnumerable<ViolationReport?>> GetViolationReportsBySubtopicAsync(int topicId);
        public IEnumerable<ViolationReport?> GetViolationReportsBySubtopic(int topicId);
        public Task<IEnumerable<ViolationReport?>> GetViolationReportsByProvinceAsync(int provinceId);
        public IEnumerable<ViolationReport?> GetViolationReportsByProvince(int provinceId);
        public Task<IEnumerable<ViolationReport?>> GetViolationReportsByDistrictAsync(int districtId);
        public IEnumerable<ViolationReport?> GetViolationReportsByDistrict(int districtId);

    }
}
