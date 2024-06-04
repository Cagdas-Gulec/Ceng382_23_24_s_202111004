using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reservation.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Reservation.Pages
{
    public class CreateReservationModel : PageModel
    {
        private readonly UniversityReservationSystemContext _context;
        private readonly ILogger<CreateReservationModel> _logger;

        public CreateReservationModel(UniversityReservationSystemContext context, ILogger<CreateReservationModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Reservation.Models.Reservation Reservation { get; set; } = new Reservation.Models.Reservation();

        public IList<Room> Rooms { get; set; } = new List<Room>();

        public async Task<IActionResult> OnGetAsync(int roomId)
        {
            _logger.LogInformation("OnGetAsync called with roomId: {RoomId}", roomId);

            Rooms = await _context.Rooms.ToListAsync();
            Reservation = new Reservation.Models.Reservation
            {
                Roomid = roomId,
                Username = HttpContext.Session.GetString("UserEmail") ?? string.Empty
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("OnPostAsync called with Reservation: {@Reservation}", Reservation);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is invalid.");
                Rooms = await _context.Rooms.ToListAsync();
                return Page();
            }

            Reservation.Startdate = DateTime.SpecifyKind(Reservation.Startdate, DateTimeKind.Utc);
            Reservation.Enddate = DateTime.SpecifyKind(Reservation.Enddate, DateTimeKind.Utc);

            _context.Reservations.Add(Reservation);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Reservation created successfully.");
            return RedirectToPage("/MyReservation");
        }
    }
}
