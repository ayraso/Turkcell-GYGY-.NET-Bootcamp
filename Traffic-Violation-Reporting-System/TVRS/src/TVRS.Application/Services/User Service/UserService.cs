using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Requests;
using TVRS.Application.DTOs.Responses;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories;

namespace TVRS.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper) 
        { 
            this._userRepository = userRepository;
            this._mapper = mapper;
        }
        public bool CheckEmailExists(string email)
        {
            return _userRepository
                                  .GetAllUsers()
                                  .Any(u => u.Email == email);
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await _userRepository
                                        .GetAllUsersAsync()
                                        .ContinueWith(users => users.Result
                                        .Any(u => u.Email == email));
        }

        public bool CheckTinExists(long tin)
        {
            return _userRepository
                                 .GetAllUsers()
                                 .Any(u => u.Tin == tin);
        }

        public async Task<bool> CheckTinExistsAsync(long tin)
        {
            return await _userRepository
                                        .GetAllUsersAsync()
                                        .ContinueWith(users => users.Result
                                        .Any(u => u.Tin == tin));
        }

        public void CreateNewUser(NewUserRequest newUserRequest)
        {
            var user = _mapper.Map<User>(newUserRequest);
            _userRepository.AddUser(user);
        }

        public async Task CreateNewUserAsync(NewUserRequest newUserRequest)
        {
            var user = _mapper.Map<User>(newUserRequest);
            await _userRepository.AddUserAsync(user);
        }

        public DisplayUserResponse? GetUserInfoByUserId(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            return _mapper.Map<DisplayUserResponse>(user);
        }

        public async Task<DisplayUserResponse?> GetUserInfoByUserIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<DisplayUserResponse>(user);
        }

        public DisplayUserResponse? UpdateUser(UpdateUserRequest updateUserRequest)
        {
            var existingUser = _userRepository.FindUserById(updateUserRequest.Id);
            if (existingUser == null)  return null;


            _mapper.Map(updateUserRequest, existingUser);
            _userRepository.UpdateUser(existingUser);
            DisplayUserResponse updatedUser = _mapper.Map<DisplayUserResponse>(updateUserRequest);
            
            return updatedUser;
        }

        public async Task<DisplayUserResponse?> UpdateUserAsync(UpdateUserRequest updateUserRequest)
        {
            var existingUser = await _userRepository.FindUserByIdAsync(updateUserRequest.Id);
            if (existingUser == null) return null;

            _mapper.Map(updateUserRequest, existingUser);
            await _userRepository.UpdateUserAsync(existingUser);
            DisplayUserResponse updatedUser = _mapper.Map<DisplayUserResponse>(existingUser);

            return updatedUser;
        }

        public User? ValidateUserForLogin(long tin, string password)
        {
            var user = _userRepository.GetUserByTin(tin);
            if (user == null || user.Password != password) return null;
            return user;   
        }

        public async Task<User?> ValidateUserForLoginAsync(long tin, string password)
        {
            var user = await _userRepository.GetUserByTinAsync(tin);
            if (user == null || user.Password != password) return null;
            return user;
        }


    }
}
