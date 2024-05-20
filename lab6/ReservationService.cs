using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public class ReservationService : IReservationService
{
   ReservationRepository _repository;

    public ReservationService(ReservationRepository repository)
    {
        _repository = repository;
    }

    public void AddReservation(Reservation reservation)
    {
        _repository.AddReservation(reservation);
    }

    public void DeleteReservation(Reservation reservation)
    {
        _repository.DeleteReservation(reservation);
    }

   /*  public static List<Reservation> DisplayReservationByReserver(string reserverName)
    {
        List<Reservation> reservations = new List<Reservation>();
        foreach (var reservation in reservations)
        {
            if (reservation.ReserverName == reserverName)
            {
                reservations.Add(reservation);
            }
        }
        return reservations;
    }

    public static List<Reservation> DisplayReservationByRoom(Room room)
    {
        List<Reservation> reservations = new List<Reservation>();
        foreach (var reservation in reservations)
        {
            if (reservation.Room == room)
            {
                reservations.Add(reservation);
            }
        }
        return reservations;
    } */
    

}