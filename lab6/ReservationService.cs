using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public class ReservationService : IReservationService
{
   ReservationRepository _reservationRepository;

    public ReservationService() {
        _reservationRepository = new ReservationRepository();
    }
   
    public void AddReservation(Reservation reservation)
    {
        _reservationRepository.AddReservation(reservation);
    }

    public void DeleteReservation(Reservation reservation)
    {
        _reservationRepository.DeleteReservation(reservation);
    }

    public List<Reservation> DisplayReservationByReserver(string reserverName)
    {
        List<Reservation> reservations = _reservationRepository.GetAllReservations();
        return reservations.Where(r => r.ReserverName == reserverName).ToList();
    }

    public List<Reservation> DisplayReservationByRoomId(string RoomId)
    {
        List<Reservation> reservations = _reservationRepository.GetAllReservations();
        return reservations.Where(r => r.Room.RoomId == RoomId).ToList();
    }
    

}