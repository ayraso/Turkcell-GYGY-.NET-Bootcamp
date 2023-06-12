using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Responses;

namespace TVRS.Application.Services.Option_Service
{
    public interface IDistrictService
    {
        public IEnumerable<DisplayDistrictResponse> GetAllDistricts();
        public Task<IEnumerable<DisplayDistrictResponse>> GetAllDistrictsAsync();
        public IEnumerable<DisplayDistrictResponse> GetAllDistrictsByProvince(int provinceId);
        public Task<IEnumerable<DisplayDistrictResponse>> GetAllDistrictsByProvinceAsync(int provinceId);

    }
}
