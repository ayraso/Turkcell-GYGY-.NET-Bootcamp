using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories.Common;

namespace TVRS.Domain.Repositories
{
    public interface IMainTopicRepository : IRepository<MainTopic>
    {
        public Task DeleteByIdAsync(int id);
        public void DeleteById(int id);
        public Task<MainTopic?> GetByIdAsync(int id);
        public MainTopic? GetById(int id);
        public Task<MainTopic?> FindByIdAsync(int id);
        public MainTopic? FindById(int id);
    }
}
