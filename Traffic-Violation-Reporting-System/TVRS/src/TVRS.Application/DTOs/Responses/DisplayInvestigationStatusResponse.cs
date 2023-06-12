using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Common;

namespace TVRS.Application.DTOs.Responses
{
    public class DisplayInvestigationStatusResponse : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
