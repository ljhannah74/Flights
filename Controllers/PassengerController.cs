using Microsoft.AspNetCore.Mvc;
using Flights.ReadModels;
using Flights.Dtos;
using Flights.ReadModels;

namespace Flights.Controllers;

[ApiController]
[Route("[controller]")]
public class PassengerController : ControllerBase
{
    static private IList<NewPassengerDto> Passengers = new List<NewPassengerDto>();
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult Register(NewPassengerDto dto)
    {
        Passengers.Add(dto);
        System.Diagnostics.Debug.WriteLine(Passengers.Count);
        return CreatedAtAction(nameof(Find), new { email = dto.Email });
    }

    [HttpGet("{email}")]
    public ActionResult<PassengerRm> Find(string email)
    {
        var passenger = Passengers.FirstOrDefault(x => x.Email == email);

        if(passenger == null)
            return NotFound();

        var rm = new PassengerRm(
            passenger.Email,
            passenger.FirstName,
            passenger.LastName,
            passenger.Gender
        );

        return Ok(rm);
    }
}