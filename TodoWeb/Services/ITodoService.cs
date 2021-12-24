using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoWeb.Models;

namespace TodoWeb.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetTodoList();
        Task<Todo> GetTodoDetailById(int id);
        Task<bool> SaveTodo(Todo todoModel);
    }
}
