﻿using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BaseController:ControllerBase
    {

        private IMediator? _mediator;
        protected IMediator? Mediator => _mediator??= HttpContext.RequestServices.GetService<IMediator>();

        protected string getIpAddress()
        {
            string ipAddress = Request.Headers.ContainsKey("X-Forwarded-For")
                ? Request.Headers["X-Forwarded-For"].ToString()
                : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()
                    ?? throw new InvalidOperationException("Ip address cannot be retrieved from request");

            return ipAddress;

        }

        protected int getUserIdFromRequest()
        {
            int userId = HttpContext.User.GetUserId();

            return userId;
        }

    }
}
