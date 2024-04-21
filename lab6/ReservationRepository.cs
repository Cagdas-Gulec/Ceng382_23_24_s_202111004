using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public class ReservationRepository : IReservationRepository
{
    private List<Reservation> _reservations = new List<Reservation>();

    private List<Room> rooms = new List<Room>();

    public ReservationRepository()
    {
        _reservations = new List<Reservation>();
    }

    public void AddReservation(Reservation reservation)
    {
        _reservations.Add(reservation);
    }

    public void DeleteReservation(Reservation reservation)
    {
        _reservations.Remove(reservation);
    }

    public void loadRooms()
    {
        RoomHandler roomHandler = new RoomHandler();
        List<Room> ?loadedRooms = roomHandler.GetRooms();
        if (loadedRooms != null)
        {
            rooms = loadedRooms;
        }
    }


    public void SaveRooms(List<Room> rooms)
    {
        var roomData = new RoomData { Rooms = rooms.ToArray() };
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(roomData, options);
        File.WriteAllText(_filePath, jsonString);
    }
}
