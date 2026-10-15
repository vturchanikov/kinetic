using FleetService.Application.DTOs;
using FleetService.Application.Interfaces;
using FleetService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FleetService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusesController(IBusesService busesService) : ControllerBase
{
    [HttpGet("{code}")]
    public async Task<ActionResult<BusDto>> GetBusAsync(string code, CancellationToken canelationToken)
    {
        var bus = await busesService.GetBusByCodeAsync(code, canelationToken);

        if(bus == null)
        {
            return NotFound("No bus with this code was found");
        }

        return Ok(bus);
    }

    [HttpGet("{code}/seats")]
    public async Task<ActionResult<BusWithSeatsDto>> GetBusWithSeats(string code, CancellationToken canelationToken)
    {
        var bus = await busesService.GetBusWithSeatsByCodeAsync(code, canelationToken);

        if(bus == null)
        {
            return NotFound("No bus with this code was found");
        }

        return Ok(bus);
    }

    [HttpGet]
    public async Task<ActionResult<List<BusDto>>> GetBuses(CancellationToken cancellationToken)
    {
        var buses = await busesService.GetBusesAsync(cancellationToken);

        return Ok(buses);
    }

    [HttpGet("active")]
    public async Task<ActionResult<List<BusDto>>> GetActiveBuses(CancellationToken cancellationToken)
    {
        var buses = await busesService.GetActiveBusesAsync(cancellationToken);

        return Ok(buses);
    }
}
