using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public  record Reservation {

    public  DateTime Time { get; init; }

    public  DateTime Date { get; init; }

    public  string? ReserverName { get; init; }

    public  Room? Room { get; init; }

    public Reservation(DateTime time, DateTime date, string reserverName, Room ?room)
    {
        Time = time;
        Date = date;
        ReserverName = reserverName;
        Room = room;
    }

    public  override string ToString()
    {
        return $"Time: {Time} \n Date: {Date} \n Reserver Name: {ReserverName} \n Room: {Room} \n";
    }
}