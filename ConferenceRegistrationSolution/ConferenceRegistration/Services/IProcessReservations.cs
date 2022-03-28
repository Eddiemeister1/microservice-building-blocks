﻿using ConferenceRegistrations.Models;

namespace ConferenceRegistrations
{
    public interface IProcessReservations
    {
        Task<ConferenceConfirmation> ProcessReservationAsync(ConferenceRegistration request);
    }
}