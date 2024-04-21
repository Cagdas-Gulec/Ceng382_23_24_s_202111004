using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public class IReservationRepository
{
    public List<Reservation> getReservations()
    {
        return new List<Reservation>();
    }

    public List<Room> getRooms()
    {
        return new List<Room>();
    }

    public void addReservation(Reservation reservation)
    {
        // Add reservation
    }

    public void deleteReservation(Reservation reservation)
    {
        // Delete reservation
    }
}
