using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public interface IStudentRepository : IRepository<IStudent>
    {
        public List<IStudent> Students { get; set; }
        public List<IStudent> GetByName(string name);
        public List<IStudent> GetBySurname(string surname);
    }
}
