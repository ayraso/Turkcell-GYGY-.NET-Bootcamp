using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public class HomeroomTeacher : SubjectTeacher, IHomeroomTeacher
    {
        public IClassroom AssignedClassroomToGuide { get; set; }

        public HomeroomTeacher(ITeacher subjectTeacher) : base(subjectTeacher.MajorSubject, subjectTeacher.Name, subjectTeacher.Surname)
        {  
            this.Id = subjectTeacher.Id;
        }

        public void ViewAttandanceInfoOfStudent(IStudent student)
        {
            Console.WriteLine("The student's attendance information is being displayed.");            
        }

        public void ViewTranscriptOfStudent(IStudent student)
        {
            Console.WriteLine("The student's transcript is being displayed.");
        }

        public void SendMessageToParentsOfStudent(IStudent student)
        {
            Console.WriteLine("Your message has been send.");
        }

    }
}
