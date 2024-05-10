using indy_microservice.Data;
using indy_microservice.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace indy_microservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDTO request) {
            var response = await _authRepository.Register(
                new User { Username = request.Username }, request.Password
            );

            return !response.Success ? BadRequest(response) : Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDTO request) {
            var response = await _authRepository.Login(request.Username, request.Password);

            return !response.Success ? BadRequest(response) : Ok(response);
        }
    }
}