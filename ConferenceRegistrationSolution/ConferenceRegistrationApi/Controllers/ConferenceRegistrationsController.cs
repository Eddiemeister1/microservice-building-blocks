

namespace ConferenceRegistrationApi.Controllers;

public class ConferenceRegistrationsController : ControllerBase
{
    private readonly IProcessReservations _reservationProcessor;

    public ConferenceRegistrationsController(IProcessReservations reservationProcessor)
    {
        _reservationProcessor = reservationProcessor;
    }

    [HttpPost("conference-registrations")]
    public async Task<ActionResult> AddRegistration([FromBody] ConferenceRegistration request)
    {
        // 
        // TODO: Validate the the thing.
        // Write the Code I wish I Had
        ConferenceRegistrationRequestMessage message = new ConferenceRegistrationRequestMessage(request.Conference!, "999.999.999", Guid.NewGuid().ToString(), RegistrationStatus.Pending);

        // TODO: Store it locally in Mongo or whatever so that the user can check the status.
        // Tell, don't ask. 
         await _reservationProcessor.ProcessReservationAsync(message);
        return StatusCode(201, request);
    }
}




