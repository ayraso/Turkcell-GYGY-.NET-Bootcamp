using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Common;
using TVRS.Domain.Entities;

namespace TVRS.Application.DTOs.Requests
{
    public class NewViolationReportRequest : IDto
    {
        public long UserId { get; set; }
        public DateTime ReportDate { get; set; }
        public int SubtopicId { get; set; }
        public int DistrictId { get; set; }
        public string IncidentScene { get; set; }
        public string IncidentDate { get; set; }
        public string IncidentTime { get; set; }
        public string IncidentDescription { get; set; }
    }
}
