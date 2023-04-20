using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public class SubjectTeacher : ITeacher
    {
        public int Id { get; set; }
        public string MajorSubject { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public SubjectTeacher(string majorSubject, string name, string surname)
        {
            this.MajorSubject = majorSubject;
            this.Name = name;
            this.Surname = surname;
        }

        public void GiveFeedbackToStudent(IStudent student)
        {
            throw new NotImplementedException();
        }

        public void GiveHomeworkToClassroom(IClassroom classroom)
        {
            throw new NotImplementedException();
        }
    }
}   
