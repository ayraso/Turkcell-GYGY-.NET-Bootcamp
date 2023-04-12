using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public interface IHomeroomTeacher
    {
        public IClassroom AssignedClassroomToGuide { get; set; }
        public void ViewAttandanceInfoOfStudent(IStudent student);
        public void ViewTranscriptOfStudent(IStudent student);
        public void SendMessageToParentsOfStudent(IStudent student);

    }
}
