using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public interface IClassroomFactory : IFactory<IClassroom>
    {
        IClassroom CreateClassroom(int grade, char section, char? programType = null);
        
    }
}
