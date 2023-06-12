using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Responses;
using TVRS.Domain.Entities;
using TVRS.Domain.Repositories;

namespace TVRS.Application.Services.Option_Service
{
    public class OptionService : IOptionService
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IMainTopicRepository _mainTopicRepository;
        private readonly ISubtopicRepository _subtopicRepository;
        private readonly IMapper _mapper;
        public OptionService(IProvinceRepository provinceRepository, 
                            IDistrictRepository districtRepository, 
                            IMainTopicRepository mainTopicRepository, 
                            ISubtopicRepository subtopicRepository,
                            IMapper mapper) 
        {
            this._provinceRepository = provinceRepository;
            this._districtRepository = districtRepository;
            this._mainTopicRepository = mainTopicRepository;
            this._subtopicRepository = subtopicRepository;
            this._mapper = mapper;
        }
        public IEnumerable<DisplayDistrictResponse> GetAllDistricts()
        {
            var districts = _districtRepository.GetAll();
            return _mapper.Map<IEnumerable<DisplayDistrictResponse>>(districts);
        }

        public async Task<IEnumerable<DisplayDistrictResponse>> GetAllDistrictsAsync()
        {
            var districts = await _districtRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DisplayDistrictResponse>>(districts);
        }

        public IEnumerable<DisplayDistrictResponse> GetAllDistrictsByProvince(int provinceId)
        {
            var districts = _districtRepository.GetAllDistrictsByProvinceId(provinceId);
            return _mapper.Map<IEnumerable<DisplayDistrictResponse>>(districts);
        }

        public IEnumerable<DisplayMainTopicResponse> GetAllMainTopics()
        {
            var mainTopics = _mainTopicRepository.GetAll();
            return _mapper.Map<IEnumerable<DisplayMainTopicResponse>>(mainTopics);
        }

        public async Task<IEnumerable<DisplayMainTopicResponse>> GetAllMainTopicsAsync()
        {
            var mainTopics = await _mainTopicRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DisplayMainTopicResponse>>(mainTopics);
        }

        public IEnumerable<DisplayProvinceResponse> GetAllProvinces()
        {
            var provinces = _provinceRepository.GetAll();
            return _mapper.Map<IEnumerable<DisplayProvinceResponse>>(provinces);
        }

        public async Task<IEnumerable<DisplayProvinceResponse>> GetAllProvincesAsync()
        {
            var provinces = await _provinceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DisplayProvinceResponse>>(provinces);
        }

        public IEnumerable<DisplaySubtopicResponse> GetAllSubtopics()
        {
            var subtopics = _subtopicRepository.GetAll();
            return _mapper.Map<IEnumerable<DisplaySubtopicResponse>>(subtopics);
        }

        public async Task<IEnumerable<DisplaySubtopicResponse>> GetAllSubtopicsAsync()
        {
            var subtopics = await _subtopicRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DisplaySubtopicResponse>>(subtopics);
        }

        public IEnumerable<DisplaySubtopicResponse> GetAllSubtopicsByMainTopic(int mainTopicId)
        {
            var subtopics = _subtopicRepository.GetAllSubtopicsByMainTopic(mainTopicId);
            return _mapper.Map<IEnumerable<DisplaySubtopicResponse>>(subtopics);
        }

        public async Task<IEnumerable<DisplaySubtopicResponse>> GetAllSubtopicsByMainTopicAsync(int mainTopicId)
        {
            var subtopics = await _subtopicRepository.GetAllSubtopicsByMainTopicIdAsync(mainTopicId);
            return _mapper.Map<IEnumerable<DisplaySubtopicResponse>>(subtopics);
        }

        public async Task<IEnumerable<DisplayDistrictResponse>> GetAllDistrictsByProvinceAsync(int provinceId)
        {
            var districts = await _districtRepository.GetAllDistrictsByProvinceIdAsync(provinceId);
            return _mapper.Map<IEnumerable<DisplayDistrictResponse>>(districts);
        }
    }
}
