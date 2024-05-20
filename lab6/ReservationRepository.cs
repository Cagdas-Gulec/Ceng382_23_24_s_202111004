using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;


public class ReservationRepository : IReservationRepository
{

    private List<Reservation> _reservations = new List<Reservation>();

    private LogHandler _logHandler = new LogHandler();

    [JsonPropertyName("Room")]
    public List<Room> Rooms { get; set; }

    public void AddReservation(Reservation reservation)
    {
        _reservations.Add(reservation);
        _logHandler.handleLog("Room booked");
        SaveReservations();
    }

    public void DeleteReservation(Reservation reservation)
    {
        _reservations.Remove(reservation);
        _logHandler.handleLog("Room removed");
        SaveReservations();
    }

    public List<Reservation> GetAllReservations()
    {
        return _reservations;
    }

    public List<Room> GetRooms()
    {
        return Rooms;
    }

    public void SaveReservations()
    {
        string jsonString = JsonSerializer.Serialize(_reservations, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("LogData.json", jsonString);
    }

    public void LoadReservations()
    {
        string jsonString = File.ReadAllText("LogData.json");
        _reservations = JsonSerializer.Deserialize<List<Reservation>>(jsonString);
    }

    public void SaveRooms()
    {
        string jsonString = JsonSerializer.Serialize(Rooms, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("LogData.json", jsonString);
    }

    public void LoadRooms()
    {
        string jsonString = File.ReadAllText("LogData.json");
        Rooms = JsonSerializer.Deserialize<List<Room>>(jsonString);
    }

    




}
