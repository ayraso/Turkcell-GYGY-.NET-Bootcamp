using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.Entities
{
    public class TaskCategory
    {
        public int TaskId { get; set; }
        public TodoItem TodoItem { get; set; }

        public int CategoryId { get; set; }
        public CategoryItem Category { get; set; }
    }
}
