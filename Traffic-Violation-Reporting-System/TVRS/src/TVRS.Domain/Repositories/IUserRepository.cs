using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories.Common;

namespace TVRS.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task AddUserAsync(User entity);
        public void AddUser(User entity);
        public Task DeleteUserByIdAsync(int id);
        public void DeleteUserById(int id);
        public Task DeleteByIdAsync(int id);
        public void DeleteById(int id);
        public Task<User?> GetByIdAsync(int id);
        public User? GetById(int id);
        public Task<User?> FindByIdAsync(int id);
        public User? FindById(int id);
        public Task<IEnumerable<User?>> GetAllUsersAsync();
        public IEnumerable<User?> GetAllUsers();
        public Task<User?> GetUserByIdAsync(int id);
        public User? GetUserById(int id);
        public Task UpdateUserAsync(User entity);
        public void UpdateUser(User entity);
        public Task DeleteAllUsersAsync();
        public void DeleteAllUsers();
        public Task<User?> FindUserByIdAsync(int id);
        public User? FindUserById(int id);
        public Task<bool> IsUserExistsAsync(int id);
        public bool IsUserExists(int id);
        public Task<User?> GetUserByTinAsync(long tin);
        public User? GetUserByTin(long tin);
    }
}
