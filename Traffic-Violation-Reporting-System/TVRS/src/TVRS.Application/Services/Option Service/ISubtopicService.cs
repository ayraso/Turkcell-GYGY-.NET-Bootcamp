using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Responses;

namespace TVRS.Application.Services.Option_Service
{
    public interface ISubtopicService
    {
        public IEnumerable<DisplaySubtopicResponse> GetAllSubtopics();
        public Task<IEnumerable<DisplaySubtopicResponse>> GetAllSubtopicsAsync();
        public IEnumerable<DisplaySubtopicResponse> GetAllSubtopicsByMainTopic(int mainTopicId);
        public Task<IEnumerable<DisplaySubtopicResponse>> GetAllSubtopicsByMainTopicAsync(int mainTopicId);
    }
}
