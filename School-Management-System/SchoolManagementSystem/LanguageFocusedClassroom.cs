using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public class LanguageFocusedClassroom : IClassroom
    {
        public int Grade { get; set ; }
        public char Section { get; set ; }
        public int Id { get; set; }
        public List<IStudent>? Students { get; set; }
        public ITeacher HomeroomTeacher { get; set; }

        public LanguageFocusedClassroom(int grade, char section)

        {
            this.Grade = grade;
            this.Section = section;
        }
    }
}
