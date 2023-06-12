using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories.Common;

namespace TVRS.Domain.Repositories
{
    public interface IAttachmentRepository : IRepository<Attachment>
    {
        public Task<IEnumerable<Attachment?>> GetAttachmentsByReportIdAsync(int reportId);
        public IEnumerable<Attachment?> GetAttachmentsByReportId(int reportId);
        public Task DeleteByIdAsync(int id);
        public void DeleteById(int id);
        public Task<Attachment?> GetByIdAsync(int id);
        public Attachment? GetById(int id);
        public Task<Attachment?> FindByIdAsync(int id);
        public Attachment? FindById(int id);
    }
}
