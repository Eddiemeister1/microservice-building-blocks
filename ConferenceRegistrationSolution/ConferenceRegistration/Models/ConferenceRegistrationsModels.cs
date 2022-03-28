namespace ConferenceRegistrations.Models;

public record ConferenceInfo(string id, string name);

public record ConferenceRegistration
{
    public ConferenceInfo? Conference { get; init; }
}


public record ConferenceConfirmationConferenceResponse(string id, string name);

public record ConferenceConfirmationForResponse(string name, string email);

public record ConferenceConfirmationPaymentResponse(decimal charged, string card);

public record ConferenceConfirmation(ConferenceConfirmationConferenceResponse conference, ConferenceConfirmationForResponse for_info, ConferenceConfirmationPaymentResponse payment);