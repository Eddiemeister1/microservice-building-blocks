using Dapr.Client;

namespace ConferenceRegistrationApi.Adapters;

public class DaprReservationAdapter
{
    private readonly DaprClient _daprClient;

    public DaprReservationAdapter(DaprClient daprClient)
    {
        // TODO: This is a good place to do another one of those IOptions<> things like we did for mongo.

        _daprClient = daprClient;
    }

    public async Task PublishReservationRequestAsync(ConferenceRegistrationRequestMessage registration)
    {
        // "reservations" is the pub/sub service that we will configure.
        // "reservation-requests" is the topic we are publishing to.
        await _daprClient.PublishEventAsync("reservations", "reservation-requests", registration);
    }
}
