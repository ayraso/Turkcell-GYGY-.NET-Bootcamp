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
    public class InvestigationStatus : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<ReportLog> ReportLogs { get; set; }
    }
}
