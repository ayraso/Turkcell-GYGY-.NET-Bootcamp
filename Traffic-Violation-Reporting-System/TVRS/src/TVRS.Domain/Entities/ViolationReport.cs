using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Common;

namespace TVRS.Domain.Entities
{
    public class ViolationReport : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long UserId { get; set; }
        public DateTime ReportDateTime { get; set; }
        public int SubtopicId { get; set; }
        public Subtopic Subtopic { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        public string IncidentScene { get; set; }
        public DateTime IncidentDateTime { get; set; }
        public string IncidentDescription { get; set; }

        public ICollection<ReportLog?> ReportLogs { get; set; }
        public ICollection<Attachment?> Attachments { get; set; }

    }
}
