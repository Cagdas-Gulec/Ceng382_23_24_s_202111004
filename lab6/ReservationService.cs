using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public class ReservationService : IReservationService
{
    private ReservationHandler _reservationHandler;
    private ReservationRepository? _reservationRepository;

    public ReservationService(ReservationHandler reservationHandler)
    {
        _reservationHandler = reservationHandler;
    }

    public void reserveRoom(Reservation reservation)
    {
        _reservationHandler.bookRoom(reservation);
    }

    public void DeleteReservation(Reservation reservation)
    {
        _reservationHandler.removeBooking(reservation.ToString());
    }

}