using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.Entities
{
    public class CategoryItem
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }

        public ICollection<TaskCategory> TaskCategories { get; set; }

    }
}
