using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    static void Main()
    {
        string jsonString = "";
        var roomData = new ReservationRepository();

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
            roomData = JsonSerializer.Deserialize<ReservationRepository>(jsonString, options);
        }
        catch (JsonException)
        {
            Console.WriteLine("Invalid JSON format");
        }
        catch (Exception)
        {
            Console.WriteLine("An error occurred");
        }

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

        if (roomData?.GetRooms() != null)
        {
            Reservation r1 = new Reservation(new DateTime(2024, 10, 21, 17, 25, 32), "Cagdas Gulec", roomData.Rooms[0]);
            Reservation r2 = new Reservation(new DateTime(2019, 08, 12, 23, 47, 55), "Arda Yildiz", roomData.Rooms[1]);
            Reservation r3 = new Reservation(new DateTime(2022, 03, 5, 12, 33, 02), "Dogukan Poyraz", roomData.Rooms[2]);
            Reservation r4 = new Reservation(new DateTime(2018, 05, 7, 15, 13, 59), "Samet Gungor", roomData.Rooms[8]);

            ReservationHandler reservationHandler = new ReservationHandler(new ReservationRepository());
            reservationHandler.BookRoom(r1);
            reservationHandler.BookRoom(r2);
            reservationHandler.BookRoom(r3);
            reservationHandler.BookRoom(r4);

           /*  foreach (var reservation in reservationHandler.GetAllReservations())
            {
                Console.WriteLine($"Reservation Date: {reservation.Time}");
                Console.WriteLine($"Reserver Name: {reservation.ReserverName}");
                Console.WriteLine($"Room ID: {reservation.Room.RoomId}");
                Console.WriteLine($"Room Name: {reservation.Room.RoomName}");
                Console.WriteLine($"Room Capacity: {reservation.Room.Capacity}");
                Console.WriteLine();
            } */



            // Serialize the reservations and write them to a JSON file
            List<Reservation> reservations = new List<Reservation> { r1, r2, r3, r4 };
            string jsonString2 = JsonSerializer.Serialize(reservations, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("ReservationData.json", jsonString2);

            // Read and display the content of the JSON file
            string fileContent = File.ReadAllText("ReservationData.json");
            Console.WriteLine("Content of ReservationData.json:");
            Console.WriteLine(fileContent);

            List<LogRecord> logRecords = new List<LogRecord>
            {
                new LogRecord(new DateTime(2024, 10, 21, 17, 25, 32), "Cagdas Gulec"),
                new LogRecord(new DateTime(2019, 08, 12, 23, 47, 55), "Arda Yildiz"),
                new LogRecord(new DateTime(2022, 03, 5, 12, 33, 02), "Dogukan Poyraz"),
                new LogRecord(new DateTime(2018, 05, 7, 15, 13, 59), "Samet Gungor")
            };

            string jsonString3 = JsonSerializer.Serialize(logRecords, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("LogData.json", jsonString3);
            
            string fileContent2 = File.ReadAllText("LogData.json");
            Console.WriteLine("Content of LogData.json:");
            Console.WriteLine(fileContent2);

           /*  List<Reservation> searchReservations = ReservationService.DisplayReservationByReserver("Cagdas Gulec");

            foreach (var reservation in searchReservations)
            {
                Console.WriteLine($"Reservation Date: {reservation.Time}");
                Console.WriteLine($"Reserver Name: {reservation.ReserverName}");
                Console.WriteLine($"Room ID: {reservation.Room.RoomId}");
                Console.WriteLine($"Room Name: {reservation.Room.RoomName}");
                Console.WriteLine($"Room Capacity: {reservation.Room.Capacity}");
                Console.WriteLine();
            } */
            

        }
    }

}
