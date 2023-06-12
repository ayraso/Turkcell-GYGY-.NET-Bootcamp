using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Common;

namespace TVRS.Application.DTOs.Requests
{
    public class UpdateUserRequest : IDto
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
