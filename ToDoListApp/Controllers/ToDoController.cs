using Microsoft.AspNetCore.Mvc;
using TodoAppBussines.Abstact;
using TodoAppBussines.Concrete;
using TodoAppEntities;

namespace ToDoListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private ITodoService _todoService;
        public ToDoController()
        {
            _todoService = new TodoManeger();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_todoService.GetAllTodo());
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetToDoById(int id)
        {
            var todoItem = _todoService.GetTodoById(id);
            if (todoItem != null)
                return Ok(todoItem);
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetToDoByUser(int id)
        {
            var todoItem = _todoService.GetTodoByUser(id);
            if (todoItem != null)
                return Ok(todoItem);
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/")]
        public IActionResult GetToDoByCompleted()
        {
            List<TodoItem> completedItems = _todoService.GetTodoByCompleted();
            if (completedItems != null)
                return Ok(completedItems);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                var createdTodo = _todoService.CreateTodo(todo);
                return CreatedAtAction("Get", new { id = todo.id }, createdTodo);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var deletedTodo = _todoService.GetTodoById(id);
            if (deletedTodo != null)
            {
                _todoService.DeleteTodo(id);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] TodoItem toDo)
        {
            var editedtoDo = _todoService.GetTodoById(toDo.id);
            if (editedtoDo != null)
                return Ok(_todoService.UpdateTodo(toDo));
            return NotFound();
        }
    }
}
