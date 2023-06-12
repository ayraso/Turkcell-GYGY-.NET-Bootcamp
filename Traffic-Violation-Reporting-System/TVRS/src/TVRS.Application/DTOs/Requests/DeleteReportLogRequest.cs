using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Common;

namespace TVRS.Application.DTOs.Requests
{
    public class DeleteReportLogRequest : IDto
    {
        public int ReportId { get; set; }
        public int StatusId { get; set; }
    }
}
