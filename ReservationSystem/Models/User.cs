using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Gender { get; set; }
        public int? Age { get; set; }
    }
}
