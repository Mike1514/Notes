﻿using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Notes.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); //take and assign MediatR if _mediator is null
        internal Guid UserId => !User.Identity.IsAuthenticated 
            ? Guid.Empty 
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
