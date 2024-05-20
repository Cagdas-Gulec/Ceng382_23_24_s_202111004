using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public class LogService
{



  public List<Reservation> DisplayLogsByName(string name)
  {
    List<Reservation> reservations = new List<Reservation>();
    return reservations.Where(r => r.ReserverName == name).ToList();
  }

  /* public List<Reservation> DisplayLogs(DateTime start, DateTime end) {
    List<Reservation> reservations = new List<Reservation>();
    return reservations.Where(r => r.StartTime >= start && r.EndTime <= end).ToList();
  } */

}
