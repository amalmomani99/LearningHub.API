using LearningHub.Core.Data;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
        {
        private readonly IJWTService jwtservice;
        public JWTController(IJWTService jwtservice)
            {
            this.jwtservice = jwtservice;
            }
        [HttpPost]
        public IActionResult Auth([FromBody] Login login)
            {

            var token = jwtservice.Auth(login);
            if (token == null)
                {
                return Unauthorized();
                }
            else
                {
                return Ok(token);
                }
            }

        }
    }
