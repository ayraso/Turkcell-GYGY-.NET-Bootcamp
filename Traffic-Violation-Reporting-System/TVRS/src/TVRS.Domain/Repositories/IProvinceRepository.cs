using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories.Common;

namespace TVRS.Domain.Repositories
{
    public interface IProvinceRepository : IRepository<Province>
    {
        public Task DeleteByIdAsync(int id);
        public void DeleteById(int id);
        public Task<Province?> GetByIdAsync(int id);
        public Province? GetById(int id);
        public Task<Province?> FindByIdAsync(int id);
        public Province? FindById(int id);
    }
}
