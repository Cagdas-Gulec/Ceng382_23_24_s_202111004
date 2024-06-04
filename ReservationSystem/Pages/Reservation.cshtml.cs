using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reservation.Models;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace Reservation.Pages
{
    public class ReservationModel : PageModel
    {
        private readonly UniversityReservationSystemContext _context;

        public ReservationModel(UniversityReservationSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ReservationInput Input { get; set; } = new ReservationInput();

        public string ConfirmationMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            Rooms = _context.Rooms.ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var reservation = new Reservation.Models.Reservation
                {
                    Roomid = Input.RoomId,
                    Startdate = Input.StartDate,
                    Enddate = Input.EndDate
                };

                if (reservation.Roomid != null)
                {
                    _context.Reservations.Add(reservation);
                    _context.SaveChanges();
                    ConfirmationMessage = "Reservation was successfully created.";
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Roomid not found.");
                }
            }

            return Page();
        }

        public List<Room> Rooms { get; set; } = new List<Room>();
    }

    public class ReservationInput
    {
        [Required]
        public int RoomId { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
