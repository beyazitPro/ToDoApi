using Microsoft.AspNetCore.Mvc;
using TodoAppBussines.Abstact;
using TodoAppBussines.Abstract;
using TodoAppBussines.Concrete;
using TodoAppEntities;

namespace ToDoListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController()
        {
            _userService = new UserManeger();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetUserByID(int id)
        {
            var todoItem = _userService.GetUserById(id);
            if (todoItem != null)
                return Ok(todoItem);
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Get(int id)
        {
            var todoItem = _userService.GetUserById(id);
            if (todoItem != null)
                return Ok(todoItem);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var createdUser = _userService.CreateUser(user);
                return CreatedAtAction("Get", new { id = user.Id}, createdUser);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            var editedUser = _userService.GetUserById(user.Id);
            if (editedUser != null)
                return Ok(_userService.UpdateUser(user));
            return NotFound();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var deletedUser = _userService.GetUserById(id);
            if (deletedUser != null)
            {
                _userService.DeleteUser(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
