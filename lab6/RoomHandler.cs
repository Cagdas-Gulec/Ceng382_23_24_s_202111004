using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;


public class RoomHandler
{

    [JsonPropertyName("filePath")]
    private string _filePath = "Data.json";

    public List<Room>? GetRooms()
    {
        string jsonString = "";
        var roomData = new RoomData();

        try
        {
            jsonString = File.ReadAllText(_filePath);
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

        return roomData?.Rooms?.ToList();
    }

    public void manageRoom(Room room)
    {
        // Manage room
    }

    public List<Room> listAvailableRooms()
    {
        return new List<Room>();
    }

}
