using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories.Common;

namespace TVRS.Domain.Repositories
{
    public interface ISubtopicRepository : IRepository<Subtopic>
    {
        public Task DeleteByIdAsync(int id);
        public void DeleteById(int id);
        public Task<Subtopic?> GetByIdAsync(int id);
        public Subtopic? GetById(int id);
        public Task<Subtopic?> FindByIdAsync(int id);
        public Subtopic? FindById(int id);
        public IEnumerable<Subtopic> GetAllSubtopicsByMainTopic(int mainTopicId);
        public Task<IEnumerable<Subtopic>> GetAllSubtopicsByMainTopicIdAsync(int mainTopicId);
    }
}
