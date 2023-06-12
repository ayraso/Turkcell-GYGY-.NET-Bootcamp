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
    public class Subtopic : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MainTopicId { get; set; }
        public MainTopic MainTopic { get; set; }
        public string Title { get; set; }

        public ICollection<ViolationReport> ViolationReports { get; set; }
    }
}
