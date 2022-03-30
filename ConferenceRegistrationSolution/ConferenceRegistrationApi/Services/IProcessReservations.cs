namespace ConferenceRegistrationApi.Services;

public interface IProcessReservations
{
    Task ProcessReservationAsync(ConferenceRegistrationRequestMessage message);
}
