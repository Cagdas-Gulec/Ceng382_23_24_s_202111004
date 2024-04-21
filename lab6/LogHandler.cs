using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public class LogHandler
{
    private ILogger _logger;

    public void SetLogger(ILogger logger)
    {
        _logger = logger;
    }

    public void handleLog(string message)
    {
        _logger.Log(message);
    }

    
    /* public static List<Reservation> DisplayLogsByName(string name) {
        List<Reservation> reservations = new List<Reservation>();
        ReservationRepository reservationRepository = new ReservationRepository();
        reservations = ReservationService.DisplayReservationByReserver(name);
        return reservations;
    }

    public static List<Reservation> DisplayLogsByRoomId(string Id) {
        List<Reservation> reservations = new List<Reservation>();
        ReservationRepository reservationRepository = new ReservationRepository();
        reservations = ReservationService.DisplayReservationByRoomId(Id);
        return reservations;
    } */
    
}
