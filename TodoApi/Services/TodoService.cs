using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Context;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private TodoDbContext _context;
        public TodoService(TodoDbContext context)
        {
            _context = context;
        }
        public Todo GetTodoDetailById(int todoId)
        {
            Todo todo;
            try
            {
                todo = _context.Find<Todo>(todoId);
            }
            catch (Exception)
            {
                throw;
            }
            return todo;
        }

        public List<Todo> GetTodoList()
        {
            List<Todo> todoList;
            try
            {
                todoList = _context.Set<Todo>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return todoList;
        }

        public ResponseModel SaveTodo(Todo todoModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Todo _temp = GetTodoDetailById(todoModel.Id);
                if (_temp != null)
                {
                    _temp.Title = todoModel.Title;
                    _temp.Description = todoModel.Description;
                    _context.Update<Todo>(_temp);
                    model.Messsage = "Todo Update Successfully";
                }
                else
                {
                    _context.Add<Todo>(todoModel);
                    model.Messsage = "Todo Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
