using NoteAPI.Helper;
using NoteAPI.Models;
using NoteAPI.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using NoteAPI.DateTransferObjects;

namespace NoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUsersService _userService;

        public UserController(IUsersService service)
        {
            _userService = service;
        }

        [HttpGet]
        [Route("IsUserExistId/{id}")]
        public IActionResult IsUserExistId(int id)
        {
            return Ok(_userService.IsUserExistId(id));
        }

        [HttpGet]
        [Route("IsUserExistUsername/{username}")]
        public IActionResult IsUserExistUsername(string username)
        {
            return Ok(_userService.IsUserExistUsername(username));
        }

        [HttpGet]
        [Route("GetUserCount")]
        public IActionResult GetUserCount()
        {
            return Ok(_userService.GetUserCount());
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpGet]
        [Route("GetUserByUsername/{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            return Ok(_userService.GetUserByUsername(username));
        }

        [HttpGet]
        [Route("LoginAuthentication")]
        public IActionResult LoginAuthentication(string username, string password)
        {
            return Ok(_userService.LoginAuthentication(username, password));
        }

        [HttpPost]
        [Route("CreateUser")]
        public void CreateUser(UsersDto usersDto)
        {
            User user = usersDto.UserMap();
            _userService.CreateUser(user);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public void UpdateUser(int id, UsersDto usersDto)
        {
            User user = usersDto.UserMap();
            _userService.UpdateUser(id, user);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }


    }
}
