using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using KOI.Blueprint.Application.Devices.Dtos;
using KOI.Blueprint.Application.Devices.Commands;

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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]    
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllDevices()
        {
           var result =  "Hello World".ToString();
           await Task.Delay(100);
           return Ok(result);
        }

        [HttpPost]
        [Route("add-device")]
        [ProducesResponseType(typeof(DeviceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeviceDto>> Create([FromBody] CreateDeviceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
