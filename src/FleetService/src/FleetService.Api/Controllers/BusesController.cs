using FleetService.Application.Interfaces;
using FleetService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FleetService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusesController(IBusesService busesService) : ControllerBase
{
    [HttpGet("{code}")]
    public Task<ActionResult<Bus>> GetBusAsync(string code, CancellationToken canelationToken)
    {
        
    }
}
