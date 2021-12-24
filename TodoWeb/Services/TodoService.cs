using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TodoWeb.Models;

namespace TodoWeb.Services
{
    public class TodoService : ITodoService
    {

        private readonly HttpClient _client;

        public TodoService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Todo> GetTodoDetailById(int id)
        {
            var response = await _client.GetAsync($"http://localhost:5000/api/todo/GetTodoById/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseResult = await response.Content.ReadFromJsonAsync<Todo>();
            return responseResult;
        }
        
        public async Task<List<Todo>> GetTodoList()
        {
            var response = await _client.GetAsync($"http://localhost:5000/api/todo/GetAllTodos");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseResult = await response.Content.ReadFromJsonAsync<List<Todo>>();
            return responseResult.ToList();
        }

        public async Task<bool> SaveTodo(Todo todoModel)
        {
            var response = await _client.PostAsJsonAsync<Todo>($"http://localhost:5000/api/todo/SaveTodos",todoModel);
            return response.IsSuccessStatusCode;
        }
    }
}
