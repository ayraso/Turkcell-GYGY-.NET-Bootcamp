using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Common;

namespace TVRS.Domain.Entities
{
    public class ReportLog : IEntity
    {
        public int ReportId { get; set; }
        public ViolationReport ViolationReport { get; set; }
        public int StatusId { get; set; }
        public InvestigationStatus InvestigationStatus { get; set; }
        public string? Note { get; set; }
        public DateTime DateTime { get; set; }
    }
}
