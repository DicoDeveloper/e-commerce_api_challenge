using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WAP.E_commerce.Api.Challenge.WebApi.V1.Core
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [Authorize]
    public abstract class SimpleBaseController : ControllerBase
    {
        protected readonly ILogger logger;
        protected readonly IMediator mediator;

        public SimpleBaseController(ILogger logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }
    }
}