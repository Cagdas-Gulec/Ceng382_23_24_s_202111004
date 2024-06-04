using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reservation.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;

namespace Reservation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UniversityReservationSystemContext _context;

        public IndexModel(UniversityReservationSystemContext context)
        {
            _context = context;
        }

        public IList<Room> Rooms { get; set; } = new List<Room>();
        public IList<Reservation.Models.Reservation> ReservedRooms { get; set; } = new List<Reservation.Models.Reservation>();
        public string FilterRoomName { get; set; } = string.Empty;
        public DateTime? FilterStartDate { get; set; }
        public DateTime? FilterEndDate { get; set; }
        public int? FilterCapacity { get; set; }
        public Room Room { get; set; } = new Room();

        public async Task OnGetAsync(string filterRoomName, DateTime? filterStartDate, DateTime? filterEndDate, int? filterCapacity)
        {
            FilterRoomName = filterRoomName;
            FilterStartDate = filterStartDate;
            FilterEndDate = filterEndDate;
            FilterCapacity = filterCapacity;

            var roomsQuery = _context.Rooms.Include(r => r.Reservations).AsQueryable();
            var reservationsQuery = _context.Reservations.Include(r => r.Room).AsQueryable();

            if (!string.IsNullOrEmpty(filterRoomName))
            {
                roomsQuery = roomsQuery.Where(r => r.Name.Contains(filterRoomName));
                reservationsQuery = reservationsQuery.Where(r => r.Room.Name.Contains(filterRoomName));
            }

            if (filterStartDate.HasValue)
            {
                reservationsQuery = reservationsQuery.Where(r => r.Startdate >= filterStartDate.Value);
            }

            if (filterEndDate.HasValue)
            {
                reservationsQuery = reservationsQuery.Where(r => r.Enddate <= filterEndDate.Value);
            }

            if (filterCapacity.HasValue)
            {
                roomsQuery = roomsQuery.Where(r => r.Capacity >= filterCapacity.Value);
            }

            Rooms = await roomsQuery.ToListAsync();
            ReservedRooms = await reservationsQuery.ToListAsync();
        }

        public async Task<IActionResult> OnPostCreateRoomAsync(Room room)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteRoomAsync(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);

            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditReservationAsync(Reservation.Models.Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingReservation = await _context.Reservations.FindAsync(reservation.Id);

            if (existingReservation == null)
            {
                return NotFound();
            }

            existingReservation.Startdate = reservation.Startdate;
            existingReservation.Enddate = reservation.Enddate;

            _context.Attach(existingReservation).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteReservationAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}