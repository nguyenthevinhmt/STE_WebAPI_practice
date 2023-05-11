using JWT_test.Dto.User;
using JWT_test.Exceptions;
using JWT_test.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        [HttpPost("CreateUse")]
        public IActionResult Create(CreateUserDto input)
        {
            try
            {
                _user.Create(input);
                return Ok();
            }
            catch
            {
                return BadRequest("Tạo tài khoản thất bại");
            }
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDto input)
        {
            try
            {
                string token = _user.Login(input);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
