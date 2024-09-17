using Entities.DataTransferObject;
using Entities.Exceptions;
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

            var user = _manager.UserService.GetOneUser(id, false);

            if (user is null)
            {
               throw new UserNotFoundException(id);
            }
            return Ok(user);


        }
        [HttpPost]
        public IActionResult CreateOneUser([FromBody] UserDtoForInsertion userDto)
        {

            if (userDto is null)
            {
                return BadRequest();    // 400;
            }
            if (!ModelState.IsValid)
            {
            return UnprocessableEntity(ModelState);  // Validation Control 
            }
            var entity =  _manager.UserService.CreateOneUser(userDto);
            return StatusCode(201, entity);

        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateOneUser([FromRoute(Name = "id")] int id, [FromBody] UserDtoForUpdate userDto)
        {
            if (userDto is null)
            {
                return BadRequest();    // 400;
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);  // Validation Control 
            }

            _manager.UserService.UpdateOneUser(id, userDto, true);

            return NoContent(); // 204;
        }

        [HttpDelete("{id:int}")]

        public IActionResult DeleteUser([FromRoute(Name = "id")] int id)
        {
            _manager.UserService.DeleteOneUser(id, true);
            return NoContent(); // 204

        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateUser([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<UserDtoForUpdate> userPatch)
        {

            if(userPatch is null)
            {
                return BadRequest();
            }

            var entity = _manager.UserService.GetOneUserForPatch(id, true);

            userPatch.ApplyTo(entity.userDtoForUpdate,ModelState);

            TryValidateModel(entity.userDtoForUpdate);
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            _manager.UserService.SaveChangesForPatch(entity.userDtoForUpdate, entity.user);
            return NoContent();

        }


    }
}
