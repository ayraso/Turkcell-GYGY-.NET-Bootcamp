using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Requests;
using TVRS.Application.DTOs.Responses;

namespace TVRS.Application.Services
{
    public interface IUserService: IUserValidator
    {
        public Task CreateNewUserAsync(NewUserRequest newUserRequest);
        public void CreateNewUser(NewUserRequest newUserRequest);
        public Task<DisplayUserResponse?> UpdateUserAsync(UpdateUserRequest updateUserRequest);
        public DisplayUserResponse? UpdateUser(UpdateUserRequest updateUserRequest);
        public DisplayUserResponse? GetUserInfoByUserId(int userId);
        public Task<DisplayUserResponse?> GetUserInfoByUserIdAsync(int userId);

    }
}
