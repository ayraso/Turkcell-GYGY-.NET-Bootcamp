using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public interface IStudentFactory : IFactory<IStudent>
    {
        IStudent CreateStudent(string name, string surname, bool? isActive = null);
    }
}
