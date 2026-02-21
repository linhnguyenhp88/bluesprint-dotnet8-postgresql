using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KOI.Blueprint.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/devices")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DevicesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet]
        [Route("get-all-devices")]
        public async Task<IActionResult> GetAllDevices()
        {
           var result =  "Hello World".ToString();
           await Task.Delay(100);
           return Ok(result);
        }
    }
}
