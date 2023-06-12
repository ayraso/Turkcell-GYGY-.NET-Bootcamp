using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories;
using TVRS.Infrastructure.Data_Context;

namespace TVRS.Infrastructure.Repositories
{
    public class EFProvinceRepository : IProvinceRepository
    {
        private readonly TvrsDbContext _dbContext;

        public EFProvinceRepository(TvrsDbContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        public void Add(Province entity)
        {
            _dbContext.Provinces.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(Province entity)
        {
            await _dbContext.Provinces.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteAll()
        {
            _dbContext.Provinces.RemoveRange(_dbContext.Provinces);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAllAsync()
        {
            _dbContext.Provinces.RemoveRange(_dbContext.Provinces);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteById(int id)
        {
            var province = _dbContext.Provinces.Find(id);
            _dbContext.Provinces.Remove(province);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var province = await _dbContext.Provinces.FindAsync(id);

            _dbContext.Provinces.Remove(province);
            await _dbContext.SaveChangesAsync();
        }

        public Province? FindById(int id)
        {
            return _dbContext.Provinces.Find(id);
        }

        public async Task<Province?> FindByIdAsync(int id)
        {
            return await _dbContext.Provinces.FindAsync(id);
        }

        public IEnumerable<Province?> GetAll()
        {
            return _dbContext.Provinces.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<Province?>> GetAllAsync()
        {
            return await _dbContext.Provinces.AsNoTracking().ToListAsync();
        }

        public Province? GetById(int id)
        {
            return _dbContext.Provinces.SingleOrDefault(e => e.Id == id);
        }

        public async Task<Province?> GetByIdAsync(int id)
        {
            return await _dbContext.Provinces.SingleOrDefaultAsync(e => e.Id == id);
        }

        public bool IsExists(int id)
        {
            return _dbContext.Provinces.Any(e => e.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.Provinces.AnyAsync(e => e.Id == id);
        }

        public void Update(Province entity)
        {
            _dbContext.Provinces.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(Province entity)
        {
            _dbContext.Provinces.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
