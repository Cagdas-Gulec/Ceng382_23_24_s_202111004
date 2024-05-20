using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public class ReservationHandler
{   

    IReservationRepository _reservationRepository;

    public ReservationHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    
    }

    public void BookRoom(Reservation reservation)
    {
        _reservationRepository.AddReservation(reservation);
        
    }

    public void removeBooking(Reservation reservation)
    {
        _reservationRepository.DeleteReservation(reservation);
    
    }

    public List<Reservation> GetAllReservations()
    {
        return _reservationRepository.GetAllReservations();
    }


}
