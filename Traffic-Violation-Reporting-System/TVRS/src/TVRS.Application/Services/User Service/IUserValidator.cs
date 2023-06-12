using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Requests;
using TVRS.Application.Services.Common;
using TVRS.Domain.Entities;

namespace TVRS.Application.Services
{
    public interface IUserValidator : IValidator<User>
    {
        public Task<User?> ValidateUserForLoginAsync(long tin, string password);
        public User? ValidateUserForLogin(long tin, string password);
        public Task<bool> CheckEmailExistsAsync(string email);
        public bool CheckEmailExists(string email);
        public Task<bool> CheckTinExistsAsync(long Tin);
        public bool CheckTinExists(long Tin);
    }
}
