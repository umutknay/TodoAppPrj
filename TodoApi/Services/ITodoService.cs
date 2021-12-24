using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Context;
using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        /// <summary>
        /// get list of all todo
        /// </summary>
        /// <returns></returns>
        List<Todo> GetTodoList();

        /// <summary>
        /// get todo details by todo id
        /// </summary>
        /// <param name="todoId"></param>
        /// <returns></returns>
        Todo GetTodoDetailById(int todoId);

        /// <summary>
        ///  add edit todo
        /// </summary>
        /// <param name="todoModel"></param>
        /// <returns></returns>
        ResponseModel SaveTodo(Todo todoModel);

    }
}
