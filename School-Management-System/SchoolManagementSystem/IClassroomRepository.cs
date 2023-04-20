using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public interface IClassroomRepository : IRepository<IClassroom>
    {
        public List<IClassroom>Classrooms { get; set; }
        public IClassroom GetClassroomByCode(int grade, char section);

    }
}
