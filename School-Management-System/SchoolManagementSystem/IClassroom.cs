using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public interface IClassroom : IHasID
    {
        public int Grade { get; set; }
        public char Section { get; set; }
        public List<IStudent>? Students { get; set; }
        public ITeacher HomeroomTeacher { get; set; }        
    }
}
