
using ConferenceRegistrations.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceRegistrations.Controllers;
public class ConferenceRegistrationApiController : ControllerBase
{
    private readonly IProcessReservations _reservationProcessor;

    [HttpPost("conference-registrations")]
    public async Task<ActionResult> AddRegistration([FromBody] ConferenceRegistration request)
    {
        //Validate the thing.
        //Write the Code I wish I had
        ConferenceConfirmation response = await _reservationProcessor.ProcessReservationAsync(request);
        return StatusCode(201, request);
    }
}