using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Common;

namespace TVRS.Application.DTOs.Requests
{
    public class UpdateViolationReportRequest : IDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public string? Note { get; set; }
        public DateTime DateTime { get; set; }

    }
}
