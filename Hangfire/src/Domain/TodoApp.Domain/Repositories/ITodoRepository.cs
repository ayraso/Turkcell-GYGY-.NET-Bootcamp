﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories
{
    public interface ITodoRepository : IRepository<TodoItem>
    {
        Task AddItemAsync(TodoItem item);
        Task UpdateItemAsync(TodoItem item);
        Task DeleteItemAsync(int id);
    }
}
