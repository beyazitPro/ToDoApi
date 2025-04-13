using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppDataAccess.Abstract;
using TodoAppEntities;

namespace TodoAppDataAccess.concrete
{
    public class TodoRepository : ITodoRepository
    {
        public TodoItem CreateTodo(TodoItem todo)
        {
            using (var TodoDbContext = new TodoDbContext())
            {
                TodoDbContext.Todo.Add(todo);
                TodoDbContext.SaveChanges();
                return todo;
            }
        }

        public void DeleteTodo(int id)
        {
            using (var TodoDbContext = new TodoDbContext())
            {
                var DeletedTodo = GetTodoById(id);
                TodoDbContext.Todo.Remove(DeletedTodo);
                TodoDbContext.SaveChanges();
            }
        }

        public List<TodoItem> GetAllTodo()
        {
            using (var TodoDbContext = new TodoDbContext())
            {
                return TodoDbContext.Todo.ToList();
            }
        }

        public List<TodoItem> GetTodoByCompleted()
        {
            using (var todoDbContext = new TodoDbContext())
            {
                return todoDbContext.Todo
                    .Where(t => t.isCompleted)
                    .ToList();
            }
        }

        public TodoItem GetTodoById(int id)
        {
            using (var TodoDbContext = new TodoDbContext())
            {
                return TodoDbContext.Todo.Find(id);
            }
        }

        public List<TodoItem> GetTodoByUser(int UserId)
        {
            using (var todoDbContext = new TodoDbContext())
            {
                return todoDbContext.Todo
                    .Where(t => t.UserId==UserId)
                    .ToList();
            }
        }

        public TodoItem UpdateTodo(TodoItem todo)
        {
            using (var TodoDbContext = new TodoDbContext())
            {
                TodoDbContext.Todo.Update(todo);
                TodoDbContext.SaveChanges();
                return todo;
            }
        }
    }
}
