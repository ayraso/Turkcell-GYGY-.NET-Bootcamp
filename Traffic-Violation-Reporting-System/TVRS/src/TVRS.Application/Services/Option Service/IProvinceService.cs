using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Responses;

namespace TVRS.Application.Services.Option_Service
{
    public interface IProvinceService
    {
        public IEnumerable<DisplayProvinceResponse> GetAllProvinces();
        public Task<IEnumerable<DisplayProvinceResponse>> GetAllProvincesAsync();
    }
}
