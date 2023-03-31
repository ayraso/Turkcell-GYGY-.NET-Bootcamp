using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    public interface IDatabase
    {
        public void AddDataTo<T>(T data);
        public T GetDataFrom<T>(T data);
    }
}
