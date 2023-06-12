using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Common;

namespace TVRS.Domain.Repositories.Common
{
    public interface IRepository<T> where T : class, IEntity
    {
        public Task AddAsync(T entity);
        public void Add(T entity);
        public Task<IEnumerable<T?>> GetAllAsync();
        public IEnumerable<T?> GetAll();
        public Task UpdateAsync(T entity);
        public void Update(T entity);
        public Task DeleteAllAsync();
        public void DeleteAll();
        public Task<bool> IsExistsAsync(int id);
        public bool IsExists(int id);

    }
}
