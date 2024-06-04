using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public int Roomid { get; set; }
        public string Username { get; set; } = null!;
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }

        public virtual Room Room { get; set; } = null!;
    }
}
