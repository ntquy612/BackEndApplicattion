using BackEndApplicattion.Data;
using BackEndApplicattion.DTOs;
using BackEndApplicattion.Exceptions;
using BackEndApplicattion.Models;
using BackEndApplicattion.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BackEndApplicattion.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(DBContext context)
        {
            _userService = new UserService(context);
        }

        // GET

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var result = await _userService.GetUsers(1, 10);

            return new JsonResult(result);
        }

        // POST

        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register(RegisterUserDTO dto)
        {
            var result = await _userService.Register(dto);

            return new JsonResult(result);
        }
        [HttpPost("login")]
        public async Task<ActionResult<InfoUser>> Login(LoginDTO dto)
        {
            var result = await _userService.Login(dto);

            return new JsonResult(result);
        }

        //PUT

        [HttpPut("changePassword")]
        public async Task<ActionResult<bool>> ChangePassword(ChangePasswordDTO dto)
        {
            var result = await _userService.ChangePassword(dto);

            return new JsonResult(result);
        }

        [HttpPut("edit")]
        public async Task<ActionResult<InfoUser>> EditUser(InfoUser info)
        {
            var result = await _userService.EditUser(info);

            return new JsonResult(result);
        }

        //DELETE

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUser(Guid id)
        {
            var result = await _userService.DeleteUser(id);

            return new JsonResult(result);
        }
    }
}
