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
    public class EFUserRepository : IUserRepository
    {
        private readonly TvrsDbContext _dbContext;

        public EFUserRepository(TvrsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void AddUser(User entity)
        {
            this.Add(entity);
        }

        public async Task AddUserAsync(User entity)
        {
            await this.AddAsync(entity);  
        }

        public void DeleteAll()
        {
            _dbContext.Users.RemoveRange(_dbContext.Users);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAllAsync()
        {
            _dbContext.Users.RemoveRange(_dbContext.Users);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteAllUsers()
        {
            this.DeleteAll();
        }

        public async Task DeleteAllUsersAsync()
        {
            await this.DeleteAllAsync();
        }

        public void DeleteById(int id)
        {
            var user = _dbContext.Users.Find(id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            
        }

        public async Task DeleteByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            
        }

        public void DeleteUserById(int id)
        {
            this.DeleteById(id);
        }

        public async Task DeleteUserByIdAsync(int id)
        {
            await this.DeleteByIdAsync(id);
        }

        public User? FindById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public async Task<User?> FindByIdAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public User? FindUserById(int id)
        {
            return this.FindById(id);
        }

        public async Task<User?> FindUserByIdAsync(int id)
        {
            return await this.FindByIdAsync(id);
        }

        public IEnumerable<User?> GetAll()
        {
            return _dbContext.Users.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<User?>> GetAllAsync()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }

        public IEnumerable<User?> GetAllUsers()
        {
            return this.GetAll();
        }

        public async Task<IEnumerable<User?>> GetAllUsersAsync()
        {
            return await this.GetAllAsync();
        }

        public User? GetById(int id)
        {
            return _dbContext.Users.SingleOrDefault(e => e.Id == id);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(e => e.Id == id);
        }

        public User? GetUserById(int id)
        {
            return this.GetById(id);
        }

        public Task<User?> GetUserByIdAsync(int id)
        {
            return this.GetByIdAsync(id);
        }

        public User? GetUserByTin(long tin)
        {
            return _dbContext.Users.SingleOrDefault(e => e.Tin == tin);
        }

        public async Task<User?> GetUserByTinAsync(long tin)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(e => e.Tin == tin);
        }

        public bool IsExists(int id)
        {
            return _dbContext.Users.Any(e => e.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.Users.AnyAsync(e => e.Id == id);
        }

        public bool IsUserExists(int id)
        {
            return this.IsExists(id);
        }

        public async Task<bool> IsUserExistsAsync(int id)
        {
            return await this.IsExistsAsync(id);
        }

        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(User entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void UpdateUser(User entity)
        {
            this.Update(entity);
        }

        public async Task UpdateUserAsync(User entity)
        {
            await this.UpdateAsync(entity);
        }
    }
}
