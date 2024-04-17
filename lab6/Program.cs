﻿using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class RoomData
{
    [JsonPropertyName("Room")]
    public Room[] Rooms { get; set; }
}

public class Room
{
    [JsonPropertyName("roomId")]
    public string RoomId { get; set; }

    [JsonPropertyName("roomName")]
    public string RoomName { get; set; }

    [JsonPropertyName("capacity")]
    public int Capacity { get; set; }

    public override string ToString()
    {
        return $"{RoomName} (Capacity: {Capacity})";
    }
}

public class Reservation
{
    public DateTime Time { get; set; }
    public DateTime Date { get; set; }
    public string ReserverName { get; set; }
    public Room Room { get; set; }

    public Reservation(DateTime time, DateTime date, string reserverName, Room room)
    {
        Time = time;
        Date = date;
        ReserverName = reserverName;
        Room = room;
    }

    public override string ToString()
    {
        return $"Time: {Time} \n Date: {Date} \n Reserver Name: {ReserverName} \n Room: {Room} \n";
    }
}

public class ReservationHandler
{
    private Reservation[][] reservations;

    public ReservationHandler()
    {
        reservations = new Reservation[7][];
        for (int i = 0; i < 7; i++)
        {
            reservations[i] = new Reservation[7];
        }
    }

    public void AddReservation(Reservation reservation)
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (reservations[i][j] == null)
                {
                    reservations[i][j] = reservation;
                    return;
                }
            }
        }
    }

    public void DeleteReservation(Reservation reservation)
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < reservations[i].Length; j++)
            {
                if (reservations[i][j] != null && reservations[i][j].Time == reservation.Time && reservations[i][j].Date == reservation.Date && reservations[i][j].ReserverName == reservation.ReserverName && reservations[i][j].Room == reservation.Room)
                {
                    reservations[i][j] = null;
                    return;
                }
            }
        }
    }

    public void DisplayWeeklySchedule()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < reservations[i].Length; j++)
            {
                if (reservations[i][j] != null)
                {
                    Console.WriteLine(reservations[i][j]);
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        string jsonString = "";
        var roomData = new RoomData();

        try
        {
            string jsonfilePath = "Data.json";
            jsonString = File.ReadAllText(jsonfilePath);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
        catch (Exception)
        {
            Console.WriteLine("An error occurred");
        }

        var options = new JsonSerializerOptions
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
        };

        try
        {
            roomData = JsonSerializer.Deserialize<RoomData>(jsonString, options);
        }
        catch (JsonException)
        {
            Console.WriteLine("Invalid JSON format");
        }
        catch (Exception)
        {
            Console.WriteLine("An error occurred");
        }

        Reservation r1 = new Reservation(new DateTime(2024, 10, 21, 17, 25, 32), new DateTime(2024, 10, 21), "Cagdas Gulec", roomData.Rooms[0]);
        Reservation r2 = new Reservation(new DateTime(2019, 08, 12, 23, 47, 55), new DateTime(2019, 08, 12), "Arda Yildiz", roomData.Rooms[1]);
        Reservation r3 = new Reservation(new DateTime(2022, 03, 5, 12, 33, 02), new DateTime(2022, 03, 5), "Dogukan Poyraz", roomData.Rooms[2]);
        Reservation r4 = new Reservation(new DateTime(2018, 05, 7, 15, 13, 59), new DateTime(2018, 05, 7), "Dogukan Poyraz", roomData.Rooms[3]);

        ReservationHandler rh = new ReservationHandler();

        rh.AddReservation(r1);
        rh.AddReservation(r2);
        rh.AddReservation(r3);
        rh.AddReservation(r4);
        rh.DeleteReservation(r2);


        rh.DisplayWeeklySchedule();

        /* if (roomData?.Rooms != null)
        {
            foreach (var room in roomData.Rooms)
            {
                Console.WriteLine($"Room ID: {room.RoomId}");
                Console.WriteLine($"Room Name: {room.RoomName}");
                Console.WriteLine($"Room Capacity: {room.Capacity}");
                Console.WriteLine();
            }
        } */
    }
}
