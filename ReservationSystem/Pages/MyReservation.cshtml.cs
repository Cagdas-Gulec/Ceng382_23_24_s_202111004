using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Reservation.Pages
{
    public class MyReservationsModel : PageModel
    {
        private readonly Reservation.Models.UniversityReservationSystemContext _context;

        public MyReservationsModel(Reservation.Models.UniversityReservationSystemContext context)
        {
            _context = context;
            Reservations = new List<Reservation.Models.Reservation>();
        }

        public List<Reservation.Models.Reservation> Reservations { get; set; }

        public void OnGet()
        {
            Reservations = _context.Reservations
                .Where(r => r.Username == User.Identity.Name)
                .ToList();
        }

        public IActionResult OnPostCancel(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id && r.Username == User.Identity.Name);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }

            Reservations = _context.Reservations
                .Where(r => r.Username == User.Identity.Name)
                .ToList();
            return Page();
        }
    }
}
