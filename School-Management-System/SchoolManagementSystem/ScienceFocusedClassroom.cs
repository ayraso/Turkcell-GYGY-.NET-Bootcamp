using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public class ScienceFocusedClassroom : IClassroom
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public char Section { get ; set ; }
        public List<IStudent>? Students { get; set; }
        public ITeacher HomeroomTeacher { get; set; }


        public ScienceFocusedClassroom(int grade, char section)
        {
            this.Grade = grade;
            this.Section = section;
        }
    }
}
