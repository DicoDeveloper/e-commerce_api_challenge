using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WAP.E_commerce.Api.Challenge.Domain.Core.Dtos;
using WAP.E_commerce.Api.Challenge.Domain.Core.Handlers;
using WAP.E_commerce.Api.Challenge.Domain.Core.Queries;

namespace WAP.E_commerce.Api.Challenge.WebApi.V1.Core
{
    public abstract class BaseController<TViewModel, TGetAllQuery, TGetByIdQuery> : SimpleBaseController
        where TViewModel : BaseDto
        where TGetAllQuery : GetAllQuery, new()
        where TGetByIdQuery : GetByIdQuery, new()
    {
        protected BaseController(ILogger logger, IMediator mediator) : base(logger, mediator) { }


        [HttpGet]
        public virtual async Task<ActionResult<ResultResponse<IEnumerable<TViewModel>>>> Get(int skip = 0, int take = 20)
        {

            var query = new TGetAllQuery { Skip = skip, Take = take };

            query.Validate();
            if (query.Invalid) return BadRequest(query.Notifications);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultResponse<TViewModel>>> Get(long id)
        {
            var query = new TGetByIdQuery { Id = id };

            query.Validate();
            if (query.Invalid) return BadRequest(new ResultResponse(query.Notifications));
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}