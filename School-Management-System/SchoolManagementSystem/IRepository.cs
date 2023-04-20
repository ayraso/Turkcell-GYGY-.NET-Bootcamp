using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void DeleteById(int id);
        List<T> GetAll();
        public T GetById(int id);
    }
}
