using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace ReservationProcessor.Controllers;

public class ReservationProcessorController : ControllerBase
{
    private readonly ILogger<ReservationProcessorController> _logger;
    private readonly DaprClient _daprClient;
    public ReservationProcessorController(ILogger<ReservationProcessorController> logger, DaprClient daprClient)
    {
        _logger = logger;
        this._daprClient = daprClient;
    }

    [Topic("reservations", "reservation-requests")]
    [HttpPost("reservation-request")]
    public async Task<ActionResult> ProcessReservation([FromBody] ConferenceReservation request)
    {
        _logger.LogInformation(request.ToString());
        // ??
        if(request.conference.name == "Jeff")
        {
            _logger.LogInformation("Sending a denied..");
            await _daprClient.PublishEventAsync("reservations", "denied-reservations", request);
        } else
        {
            _logger.LogInformation("Sending an approved");
            await _daprClient.PublishEventAsync("reservations", "approved-reservations", request);
        }
        return Ok(); // Profit!
    }
}

//{ conference = ConferenceInfo { id = someid, name = Microservice World 2022 }, sub = 999.999.999, id = 07ce12d9 - 52bf - 48a8 - b342 - 1af20fbc5d3e, status = Pending }
    
public record Conference(string id, string name);
public record ConferenceReservation(Conference conference, string sub, string id);