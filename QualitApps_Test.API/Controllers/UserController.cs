using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QualitApps_Test.Models.Enums;
using QualitApps_Test.Models.Models;
using QualitApps_Test.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QualitApps_Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;
        public UserController(IUserRepository userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers/{userRole}")]
        //[Authorize(Roles = "Admin")]
        public ActionResult<ICollection<BaseUser>> GetUsers(UserRole? userRole = null)
        {
            var users = _userService.GetAllUsers();
            if (userRole != null)
            {
                users = users.Where(u => u.userRoles == userRole).ToList();
            }

            return Ok(users);
        }

        [HttpGet("GetUsers/{id}")]
        public IActionResult GetUser(Guid id)
        {
            var user = _userService.GetUserByUserId(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //[HttpGet("GetAvailableDrivers")]
        //public IActionResult GetAvailableDrivers()
        //{
        //    var users = _userService.GetAllUsers().Where(b => b.Bookings.Count < 1).ToList();

        //    if (users.Count > 0)
        //    {
        //        return new JsonResult(new
        //        {
        //            status = "error",
        //            message = $"No Drivers Available"
        //        })
        //        {
        //            StatusCode = 500
        //        };
        //    }

        //    return Ok(users);
        //}

        [HttpPost("CreateUser")]
        //[Authorize(Policy = "AdminOnly")]
        public ActionResult<BaseUser> CreateUser([FromBody] BaseUser user)
        {
            
            var newUser = _userService.CreateUser(user);

            return CreatedAtRoute("GetUser", new { id = newUser.UserId }, newUser);
        }
        [HttpPut("UpdatUser/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Task<BaseUser>>> UpdateUserAsync(BaseUser user)
        {
            var updatedUser = await _userService.UpdateUser(user);

            return CreatedAtAction("GetUser", new { id = updatedUser.UserId }, updatedUser);
        }

        [HttpDelete("DeleteUser/{id}")]
        //[Authorize(Policy = "AdminOnly")]
        public ActionResult<BaseUser> DeleteUser(Guid id)
        {
            var result = _userService.RemoveUser(id);

            if (result == 1)
            {
                return new JsonResult(new
                {
                    status = "success",
                    message = $"User with ID {id} has been deleted."
                })
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new JsonResult(new
                {
                    status = "error",
                    message = $"Failed to delete user with ID {id}."
                })
                {
                    StatusCode = 500
                };
            }
        }

    }
}
