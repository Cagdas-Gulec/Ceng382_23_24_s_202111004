using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        
         if (roomData?.Rooms != null)
        {
            foreach (var room in roomData.Rooms)
            {
                Console.WriteLine($"Room ID: {room.RoomId}");
                Console.WriteLine($"Room Name: {room.RoomName}");
                Console.WriteLine($"Room Capacity: {room.Capacity}");
                Console.WriteLine();
            }
        }

        if (roomData?.Rooms != null)
        {
            Reservation r1 = new Reservation(new DateTime(2024, 10, 21, 17, 25, 32), new DateTime(2024, 10, 21), "Cagdas Gulec", roomData.Rooms[0]);
            Reservation r2 = new Reservation(new DateTime(2019, 08, 12, 23, 47, 55), new DateTime(2019, 08, 12), "Arda Yildiz", roomData.Rooms[1]);
            Reservation r3 = new Reservation(new DateTime(2022, 03, 5, 12, 33, 02), new DateTime(2022, 03, 5), "Dogukan Poyraz", roomData.Rooms[2]);
            Reservation r4 = new Reservation(new DateTime(2018, 05, 7, 15, 13, 59), new DateTime(2018, 05, 7), "Samet Gungor", roomData.Rooms[8]);

            ReservationHandler rh = new ReservationHandler();

            rh.bookRoom(r1);
            rh.bookRoom(r2);
            rh.bookRoom(r3);
            rh.bookRoom(r4);
            rh.removeBooking("Dogukan Poyraz");


            rh.DisplayWeeklySchedule();
        }
    }
}
