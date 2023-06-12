using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Common;

namespace TVRS.Application.DTOs.Responses
{
    public class DisplayViolationReportResponse : IDto
    {
        public int Id { get; set; }
        public DateTime ReportDate { get; set; }
        public string SubtopicName { get; set; }
        public string InvestigationStatusName { get; set; }

    }
}
