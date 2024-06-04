using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public string? Photo { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
