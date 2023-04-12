using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public interface ITeacherRepository : IRepository<ITeacher>
    {
        public List<ITeacher> GetAllTeachers();
        public List<HomeroomTeacher> GetAllHomeroomTeachers();
        public List<ITeacher> GetByName(string name);
        public List<ITeacher> GetBySurname(string surname);
        public List<ITeacher> GetTeachersByMajorSubject(string majorSubject);
    }
}
