using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Common;
using TVRS.Domain.Entities;

namespace TVRS.Application.DTOs.Responses
{
    public class DisplayDetailedViolationReportResponse : IDto
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public DateTime ReportDate { get; set; }
        public  string MainTopicTitle { get; set; }
        public string SubtopicTitle { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string IncidentScene { get; set; }
        public DateTime IncidentDateTime { get; set; }
        public string IncidentDescription { get; set; }
        public string InvestigationStatusName { get; set; }
        public string InvestigationStatusLastUpdateDateTime { get; set; }
    }
}
