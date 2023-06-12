using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories.Common;

namespace TVRS.Domain.Repositories
{
    public interface IDistrictRepository : IRepository<District>
    {
        public Task DeleteByIdAsync(int id);
        public void DeleteById(int id);
        public Task<District?> GetByIdAsync(int id);
        public District? GetById(int id);
        public Task<District?> FindByIdAsync(int id);
        public District? FindById(int id);
        public IEnumerable<District> GetAllDistrictsByProvinceId(int provinceId);
        public Task<IEnumerable<District>> GetAllDistrictsByProvinceIdAsync(int provinceId);
    }
}
