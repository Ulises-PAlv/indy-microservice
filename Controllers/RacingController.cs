using indy_microservice.RacingService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace indy_microservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RacingController : ControllerBase
    {
        private readonly IRacingService _racingService;

        public RacingController(IRacingService racingService)
        {
            _racingService = racingService;
        }
    }
}