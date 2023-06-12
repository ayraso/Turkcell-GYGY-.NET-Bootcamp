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
    public class EFDistrictRepository : IDistrictRepository
    {
        private readonly TvrsDbContext _dbContext;

        public EFDistrictRepository(TvrsDbContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        public void Add(District entity)
        {
            _dbContext.Districts.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(District entity)
        {
            await _dbContext.Districts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteAll()
        {
            _dbContext.Districts.RemoveRange(_dbContext.Districts);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAllAsync()
        {
            _dbContext.Districts.RemoveRange(_dbContext.Districts);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteById(int id)
        {
            var district = _dbContext.Districts.Find(id);
            _dbContext.Districts.Remove(district);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var district = await _dbContext.Districts.FindAsync(id);

            _dbContext.Districts.Remove(district);
            await _dbContext.SaveChangesAsync();
        }

        public District? FindById(int id)
        {
            return _dbContext.Districts.Find(id);
        }

        public async Task<District?> FindByIdAsync(int id)
        {
            return await _dbContext.Districts.FindAsync(id);
        }

        public IEnumerable<District?> GetAll()
        {
            return _dbContext.Districts.AsNoTracking()
                                       .ToList();
        }

        public async Task<IEnumerable<District?>> GetAllAsync()
        {
            return await _dbContext.Districts.AsNoTracking()
                                             .ToListAsync();
        }

        public IEnumerable<District> GetAllDistrictsByProvinceId(int provinceId)
        {
            return _dbContext.Districts
                             .AsNoTracking()
                             .Where(d => d.ProvinceId == provinceId)
                             .ToList();
        }

        public async Task<IEnumerable<District>> GetAllDistrictsByProvinceIdAsync(int provinceId)
        {
            return await _dbContext.Districts
                                   .AsNoTracking() 
                                   .Where(d => d.ProvinceId == provinceId)
                                   .ToListAsync();
        }

        public District? GetById(int id)
        {
            return _dbContext.Districts.SingleOrDefault(e => e.Id == id);
        }

        public async Task<District?> GetByIdAsync(int id)
        {
            return await _dbContext.Districts.SingleOrDefaultAsync(e => e.Id == id);
        }

        public bool IsExists(int id)
        {
            return _dbContext.Districts.Any(e => e.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.Districts.AnyAsync(e => e.Id == id);
        }

        public void Update(District entity)
        {
            _dbContext.Districts.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(District entity)
        {
            _dbContext.Districts.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
