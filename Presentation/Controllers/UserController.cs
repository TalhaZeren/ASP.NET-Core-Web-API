using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {

        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _manager.UserService.GetAllUsers(false);
            return Ok(users);
        }

        [HttpGet("{id:int}")]

        public IActionResult GetOneUser([FromRoute(Name = "id")] int id) // Necessary to clean code.
        {
            try
            {
                var user = _manager.UserService.GetOneUser(id, false);

                if (user is null)
                {
                    return NotFound();
                }
                return Ok(user);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOneUser([FromBody] User user)
        {
            try
            {
                if (user is null)
                {
                    return BadRequest();    // 400;
                }
                _manager.UserService.CreateOneUser(user);
                return StatusCode(201, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateOneUser([FromRoute(Name = "id")] int id, [FromBody] User user)
        {
            try
            {
                if (user is null)
                {
                    return BadRequest();    // 400;
                }

                _manager.UserService.UpdateOneUser(id, user, true);

                return NoContent(); // 204;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]

        public IActionResult DeleteUser([FromRoute(Name = "id")] int id)
        {

            try
            {
                _manager.UserService.DeleteOneUser(id, true);
                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateUser([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<User> userPatch)
        {
            try
            {
                var entity = _manager.UserService.GetOneUser(id, false);

                if (entity == null || id != entity.Id)
                {
                    return NotFound();
                }

                userPatch.ApplyTo(entity);
                _manager.UserService.UpdateOneUser(id, entity, true);

                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
