﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppEntities;


namespace TodoAppBussines.Abstact
{
    public interface ITodoService
    {
        List<TodoItem> GetAllTodo();
        List<TodoItem> GetTodoByCompleted();
        List<TodoItem> GetTodoByUser(int UserId);
        TodoItem GetTodoById(int id);
        TodoItem CreateTodo(TodoItem todo);
        TodoItem UpdateTodo(TodoItem todo);
        void DeleteTodo(int id);
    }
}
