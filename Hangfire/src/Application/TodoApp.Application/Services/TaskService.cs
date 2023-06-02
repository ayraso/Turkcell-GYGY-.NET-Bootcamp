using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;
using TodoApp.Infrastructure.Data;
using TodoApp.Infrastructure.Repositories;

namespace TodoApp.Application.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TodoItem>> GetAllTasksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TodoItem> GetTaskByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddTaskAsync(TodoItem item)
        {
            await _repository.AddItemAsync(item);
        }

        public async Task UpdateTaskAsync(TodoItem item)
        {
            await _repository.UpdateItemAsync(item);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _repository.DeleteItemAsync(id);
        }
    }
}
