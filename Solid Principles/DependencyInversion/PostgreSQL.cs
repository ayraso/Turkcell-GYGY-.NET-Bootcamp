using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    public class PostgreSQL : IDatabase
    {
        public PostgreSQL() { }

        public void AddDataTo<T>(T data) 
        {
            Console.WriteLine($"data of {data} has been saved to PostgreSQL database.");
        }

        public T GetDataFrom<T>(T data)
        {
            throw new NotImplementedException();
        }
    }
}
