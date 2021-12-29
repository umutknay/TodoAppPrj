using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        ITodoService _todoService;
        private readonly ILogger _logger;
        public TodoController(ITodoService service,ILogger<TodoController> logger)
        {
            _todoService = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllTodos()
        {
            _logger.LogInformation("GET request, GetAllTodos method");
            try
            {
                var todos = _todoService.GetTodoList();
                if (todos == null) return NotFound();
            
                return Ok(todos);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetTodoById(int id)
        {
            _logger.LogInformation("Get request, GetTodoById method" + id);
            try
            {
                var todo = _todoService.GetTodoDetailById(id);
                if (todo == null) return NotFound();
                
                return Ok(todo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveTodos(Todo todo)
        {
            _logger.LogInformation("Post request, saveTodo method");
            try
            {
                var todos = _todoService.SaveTodo(todo);
                
                return Ok(todos);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
