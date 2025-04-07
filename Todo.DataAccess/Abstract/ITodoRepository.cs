using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppEntities;

namespace TodoAppDataAccess.Abstract
{
    public interface ITodoRepository
    {
        List<TodoItem> GetAllTodo();
        List<TodoItem> GetTodoByCompleted();
        TodoItem GetTodoById(int id);
        TodoItem CreateTodo(TodoItem todo);
        TodoItem UpdateTodo(TodoItem todo);
        void DeleteTodo(int id);

    }

}
