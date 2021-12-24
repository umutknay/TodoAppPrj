using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public TodoController(ITodoService service)
        {
            _todoService = service;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllTodos()
        {
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
        [Route("[action]/id")]
        public IActionResult GetTodoById(int id)
        {
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
