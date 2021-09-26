using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WAP.E_commerce.Api.Challenge.Domain.Core.Dtos;

namespace PayPow.Platform.Backend.WebApi.V1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly SecretConfig _cecretConf;

        public AuthController(ILogger<AuthController> logger, IMediator mediator, IOptions<SecretConfig> confg)
        {
            _cecretConf = confg.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<dynamic> GetToken(string clientToken)
        {
            if (!_cecretConf.Key.Equals(clientToken))
                return NotFound(new { message = "Token inválidos" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(clientToken);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            return new
            {
                token = token
            };
        }
    }
}
