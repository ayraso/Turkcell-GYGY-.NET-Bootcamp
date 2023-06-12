using TVRS.Application.DTOs.Requests;
using TVRS.Application.DTOs.Responses;

namespace TVRS.WebUI.Models
{
    public class ReportCreatingModel
    {
        public IEnumerable<DisplaySubtopicResponse> Subtopics { get; set; }
        public IEnumerable<DisplayDistrictResponse> Districts { get; set; }

        public NewViolationReportRequest NewReport { get; set; }
    }
}
