using Dapr;

namespace ConferenceRegistrationApi.Controllers;

public class ReservationResultsController : ControllerBase
{
    private readonly ILogger<ReservationResultsController> _logger;

    public ReservationResultsController(ILogger<ReservationResultsController> logger)
    {
        _logger = logger;
    }
    [Topic("reservations", "approved-reservations")]
    [HttpPost("approved-res")]
    public async Task<ActionResult> ReservationApproved([FromBody] ConferenceRegistrationRequestMessage message)
    {
        _logger.LogInformation("Approved a reservation...");
        return Ok();
    }

    [HttpPost("denied-res")]
    [Topic("reservations", "denied-reservations")]
    public async Task<ActionResult> ReservationDenied([FromBody] ConferenceRegistrationRequestMessage message)
    {
        _logger.LogInformation("Denied a Reservation");
        return Ok();
    }
}
