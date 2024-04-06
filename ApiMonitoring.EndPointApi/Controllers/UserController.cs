using ApiMonitoring.Application.DTOs.UserDtos;
using ApiMonitoring.Application.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMonitoring.EndPointApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var result = _userServices.RegisterUserAsync(registerUserDTO);

            return Ok(result);
        }
    }
}
