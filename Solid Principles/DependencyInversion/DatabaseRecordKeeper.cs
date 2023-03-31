using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    public class DatabaseRecordKeeper
    {
        public DatabaseRecordKeeper(IDatabase db) { this.Database = db; }

        public IDatabase Database { get; set; }

        public void Save<T>(T data) 
        {
            Database.AddDataTo(data);
        }
        public T Load<T>(T data) 
        { 
            return default(T);
        }
    }
}
