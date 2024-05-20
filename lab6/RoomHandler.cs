using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;


public class RoomHandler
{

    public void ManageRoom(Room room) {
        Console.WriteLine($"Room ID: {room.RoomId}");
        Console.WriteLine($"Room Name: {room.RoomName}");
        Console.WriteLine($"Room Capacity: {room.Capacity}");
        Console.WriteLine();
    }

   
}
