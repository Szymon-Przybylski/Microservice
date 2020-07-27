using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using ShippingService.Api.Models;
using ShippingService.Application.Commands;
using ShippingService.Application.DTOs;
using ShippingService.Application.Queries;

namespace ShippingService.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public ShipmentController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("id:Guid")]
        public async Task<ActionResult<ShipmentDTO>> GetShipment(Guid id)
        {
            return Ok(await _queryDispatcher.QueryAsync(new GetShipment
            {
                ShipmentId = id
            }));
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateShipment(CreateShippingRequestModel request)
        {
            Guid id = Guid.NewGuid();
            await _commandDispatcher.SendAsync(new CreateShipment(id, request.ShipmentName));

            return Created($"api/{id}", null);
        }
    }
}
