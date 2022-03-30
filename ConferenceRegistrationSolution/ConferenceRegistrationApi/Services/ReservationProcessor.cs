namespace ConferenceRegistrationApi.Services;

public class ReservationProcessor : IProcessReservations
{
    private readonly DaprReservationAdapter _reservationAdapter;
    private readonly ILogger<ReservationProcessor> _logger;
    public ReservationProcessor(DaprReservationAdapter reservationAdapter, ILogger<ReservationProcessor> logger)
    {
        _reservationAdapter = reservationAdapter;
        _logger = logger;
    }

    public async Task ProcessReservationAsync(ConferenceRegistrationRequestMessage message)
    {
        // Todo: All the crap jeff doesn't do in class. Validating stuff beyond what you can do in the controller, error handling (if the adapter throws an exception, this is a good place to figure out what that means, etc. 
        _logger.LogInformation(message.ToString());
        await _reservationAdapter.PublishReservationRequestAsync(message);
    }
}
