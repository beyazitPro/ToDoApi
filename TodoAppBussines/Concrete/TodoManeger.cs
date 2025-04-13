using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppBussines.Abstact;
using TodoAppDataAccess.Abstract;
using TodoAppDataAccess.concrete;
using TodoAppEntities;

namespace TodoAppBussines.Concrete
{
    public class TodoManeger : ITodoService
    {
        private ITodoRepository _Repository;
        public TodoManeger()
        {
            _Repository =  new TodoRepository();
        }
        public TodoItem CreateTodo(TodoItem todo)
        {
            return _Repository.CreateTodo(todo);
        }

        public void DeleteTodo(int id)
        {
            _Repository.DeleteTodo(id);
        }

        public List<TodoItem> GetAllTodo()
        {
            return _Repository.GetAllTodo();
        }

        public List<TodoItem> GetTodoByCompleted()
        {
            return _Repository.GetTodoByCompleted();
        }

        public TodoItem GetTodoById(int id)
        {
            if (id>0)
                return _Repository.GetTodoById(id);
            throw new Exception("id can not be less than 1");

        }

        public List<TodoItem> GetTodoByUser(int UserId)
        {
            return _Repository.GetTodoByUser(UserId);
        }

        public TodoItem UpdateTodo(TodoItem todo)
        {
            return _Repository.UpdateTodo(todo);
        }
    }
}
