using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public interface ITeacher : IHasID
    {
        public string MajorSubject { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public void GiveHomeworkToClassroom(IClassroom classroom);
        public void GiveFeedbackToStudent(IStudent student);
    }
}
