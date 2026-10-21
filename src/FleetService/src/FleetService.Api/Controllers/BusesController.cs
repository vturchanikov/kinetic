using FleetService.Application.DTOs;
using FleetService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FleetService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusesController(IBusesService busesService) : ControllerBase
{
    [HttpGet("{code}", Name = "GetBusByCode")]
    public async Task<ActionResult<BusDto>> GetByCode(string code, CancellationToken canelationToken)
    {
        var bus = await busesService.GetByCodeAsync(code, canelationToken);

        if(bus == null)
        {
            return NotFound("No bus with this code was found");
        }

        return Ok(bus);
    }

    [HttpGet("{code}/seats")]
    public async Task<ActionResult<BusWithSeatsDto>> GetByCodeWithSeats(string code, CancellationToken canelationToken)
    {
        var bus = await busesService.GetByCodeWithSeatsAsync(code, canelationToken);

        if(bus == null)
        {
            return NotFound("No bus with this code was found");
        }

        return Ok(bus);
    }

    [HttpGet]
    public async Task<ActionResult<List<BusDto>>> GetAll(CancellationToken cancellationToken)
    {
        var buses = await busesService.GetAllAsync(cancellationToken);

        return Ok(buses);
    }

    [HttpGet("active")]
    public async Task<ActionResult<List<BusDto>>> GetActive(CancellationToken cancellationToken)
    {
        var buses = await busesService.GetActiveAsync(cancellationToken);

        return Ok(buses);
    }

    [HttpPost("{code}/activate")]
    public Task<ActionResult> Activate(string code, CancellationToken cancellationToken)
    {
        return ExecuteBusActionAsync(code, cancellationToken, busesService.ActivateAsync);
    }

    [HttpPost("{code}/repair")]
    public Task<ActionResult> SendToRepair(string code, CancellationToken cancellationToken)
    {
        return ExecuteBusActionAsync(code, cancellationToken, busesService.SendToRepairAsync);
    }

    [HttpPost("{code}/deactivate")]
    public Task<ActionResult> Deactivate(string code, CancellationToken cancellationToken)
    {
        return ExecuteBusActionAsync(code, cancellationToken, busesService.DeactivateAsync);
    }

    [HttpPost("{code}/retire")]
    public Task<ActionResult> Retire(string code, CancellationToken cancellationToken)
    {
        return ExecuteBusActionAsync(code, cancellationToken, busesService.RetireAsync);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody]CreateBusDto bus,  CancellationToken cancellationToken)
    {
        var createdBus = await busesService.CreateAsync(bus, cancellationToken);

        return CreatedAtRoute("GetByCode", new { code = bus.Code }, createdBus);
    }

    private async Task<ActionResult> ExecuteBusActionAsync(string code, CancellationToken cancellationToken,
        Func<string, CancellationToken, Task> action)
    {
        await action(code, cancellationToken);

        return NoContent();
    }
}