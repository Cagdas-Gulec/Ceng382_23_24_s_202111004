using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public class ReservationHandler
{
    private Reservation[][]? reservations;

    public ReservationHandler()
    {
        reservations = new Reservation[7][];
        for (int i = 0; i < 7; i++)
        {
            reservations[i] = new Reservation[7];
        }
    }

    public void bookRoom(Reservation reservation)
    {
        for (int i = 0; i < 7; i++)
        {
            if (reservations[i] != null)
            {
                for (int j = 0; j < reservations[i].Length; j++)
                {
                    if (reservations[i][j] == null)
                    {
                        reservations[i][j] = reservation;
                        return;
                    }
                }
            }
            else
            {
                reservations[i] = new Reservation[7];
                reservations[i][0] = reservation;
                return;
            }
        }
    }

    public void removeBooking(string reservationId)
    {
        for (int i = 0; i < 7; i++)
        {
            if (reservations[i] != null) 
            {
                for (int j = 0; j < reservations[i].Length; j++)
                {
                    if (reservations[i][j] != null && reservations[i][j].ReserverName == reservationId)
                    {
                        reservations[i][j] = null!;
                    }
                }
            }
            else
            {
                Console.WriteLine("No reservations for this day");
            }
        }
    }

    public List<Reservation> GetReservationsByReserver(string reserver)
    {
       

        return new List<Reservation>(); 
    }
    
    public void DisplayWeeklySchedule()
    {
        for (int i = 0; i < 7; i++)
        {
            if (reservations[i] != null)
            {
                for (int j = 0; j < reservations[i].Length; j++)
                {
                    if (reservations[i][j] != null)
                    {
                        Console.WriteLine(reservations[i][j]);
                    }
                }
            }
            else
            {
                Console.WriteLine("No reservations for this day");
            }
        }
    }
}
