using Microsoft.AspNetCore.Mvc;
using ToDoListApp.models;

namespace ToDoListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private static List<ToDoItem> toDoItems = new List<ToDoItem>();

        [HttpGet]
        public List<ToDoItem> Get()
        {
            return toDoItems;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetToDoById(int id)
        {
            var todoItem = toDoItems.FirstOrDefault(todo => todo.id == id);
            if (todoItem != null)
                return Ok(todoItem);
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{isCompleteted}")]
        public IActionResult GetToDoByCompleted(bool isCompleteted)
        {
            var completedItems = toDoItems.Where(item => item.isCompleted==isCompleteted).ToList();
            if (completedItems != null)
                return Ok(completedItems);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDoItem toDo)
        {
            toDo.id = toDoItems.Count + 1;
            toDoItems.Add(toDo);
            return CreatedAtAction("Get",new {id=toDo.id},toDo);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var deletedTodo = toDoItems.FirstOrDefault(todo => todo.id == id);
            if (deletedTodo != null)
            {
                toDoItems.Remove(deletedTodo);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] ToDoItem toDo)
        {
            var editedtoDo = toDoItems.FirstOrDefault(todo => todo.id == toDo.id);
            if (editedtoDo != null)
            {
                editedtoDo.title = toDo.title;
                editedtoDo.description = toDo.description;
                editedtoDo.isCompleted = toDo.isCompleted;
                return Ok(toDo);
            }
            return NotFound();
        }
    }
}
