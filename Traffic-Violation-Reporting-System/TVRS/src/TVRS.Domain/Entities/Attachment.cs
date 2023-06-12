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
    public class Attachment : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ReportId { get; set; }
        public ViolationReport Report { get; set; }
        public byte[] Image { get; set; } // Or string URL for file location
    }
}
