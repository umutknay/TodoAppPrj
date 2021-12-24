using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoWeb.Models;
using TodoWeb.Services;

namespace TodoWeb.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _todoService.GetTodoList());
            //return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _todoService.SaveTodo(todo);
            return RedirectToAction(nameof(Index));
        }
    }
}
