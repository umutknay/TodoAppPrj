using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Controllers;
using TodoApi.Models;
using TodoApi.Services;
using Xunit;

namespace TodoApiTest
{
    public class TodoTest
    {
        private readonly Mock<ITodoService> _mockTodo;
        private readonly TodoController _controller;

        public TodoTest()
        {
            _mockTodo = new Mock<ITodoService>();
            _controller = new TodoController(_mockTodo.Object,null);

        }

        public List<Todo> GetAllToto()
        {
            List<Todo> todos = new List<Todo>()
            {
                new Todo{ Id=1, Title="Twitter apiye üye olunacak", Description="Twitter apiye üye olunacak"},
                new Todo{ Id=2, Title="Twitter api ile twit çekilecek", Description="Twitter api ile twit çekilecek"}
            };
            return todos;
        }

        [Fact]
        public  void GetAll_ActionExecute_ReturnViewForIndex()
        {
            var result =  _controller.GetAllTodos();
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public void GetTotos_ActionExecute_ReturnOkResultWitTodo()
        {
            var totos = GetAllToto();
            _mockTodo.Setup(t => t.GetTodoList()).Returns(totos);
            var result = _controller.GetAllTodos();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnTodo = Assert.IsAssignableFrom<List<Todo>>(okResult.Value);
            Assert.Equal<int>(2, returnTodo.Count);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetTodo_IdValid_ReturnOkResult(int id)
        {
            var todos = GetAllToto();
            var todo = todos.First(x => x.Id == id);
            _mockTodo.Setup(x => x.GetTodoDetailById(id)).Returns(todo);
            var result = _controller.GetTodoById(id);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnTodo = Assert.IsType<Todo>(okResult.Value);
            Assert.Equal(id, returnTodo.Id);
            Assert.Equal(todo.Title, returnTodo.Title);
        }
        [Theory]
        [InlineData(3)]
        public void GetTodo_IdValid_ReturnNotFound(int id)
        {
            Todo todo = null;
            _mockTodo.Setup(t => t.GetTodoDetailById(id)).Returns(todo);
            var Result = _controller.GetTodoById(id);
            Assert.IsType<NotFoundResult>(Result);
        }

    }
}
