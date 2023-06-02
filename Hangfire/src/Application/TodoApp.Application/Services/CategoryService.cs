using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Infrastructure.Data;
using TodoApp.Infrastructure.Repositories;

namespace TodoApp.Application.Services
{
    public class CategoryService : EFCoreCategoryRepository
    {
        public CategoryService(TodoDbContext context) : base(context)
        {

        }
    }
}
