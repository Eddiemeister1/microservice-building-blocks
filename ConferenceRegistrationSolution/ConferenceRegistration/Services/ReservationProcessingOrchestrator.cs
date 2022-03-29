using ConferenceRegistrations.Models;

namespace ConferenceRegistrations.Services;
    public class ReservationProcessingOrchestrator : IProcessReservations
    {

        public Task<ConferenceConfirmation> ProcessReservationAsync(ConferencesRegistration request)
        {
        //- I have the id, but is that a real conference? Has it already happened? Is it full?
        // - Is this a real user? Are they allowed to attend conferences, all that jazz... and WHAT IS 
        // THERE NAME AND EMAIL ADDRESS
        // - if the above two are true, charge their credit card.
        // - if that worked, then reghister them for the conference.
        // - what else? Send a confirmation email? blah blah blah
        return null;
        }
    }
