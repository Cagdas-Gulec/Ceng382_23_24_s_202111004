using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Reservation.Models;
using System.Linq;

namespace Reservation.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly UniversityReservationSystemContext _context;

        public ProfileModel(UniversityReservationSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserProfile Profile { get; set; }

        public string SuccessMessage { get; set; }

        public IActionResult OnGet()
        {
            var username = User.Identity?.Name;
            if (username != null)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    Profile = new UserProfile
                    {
                        Username = user.Username,
                        Email = user.Email,
                        Gender = user.Gender,
                        Age = user.Age
                    };
                }
                else
                {
                    return RedirectToPage("/Error");
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity?.Name;
                if (username != null)
                {
                    var user = _context.Users.FirstOrDefault(u => u.Username == username);
                    if (user != null)
                    {
                        user.Email = Profile.Email;
                        user.Gender = Profile.Gender;
                        user.Age = Profile.Age;
                        if (!string.IsNullOrEmpty(Profile.NewPassword))
                        {
                            user.Password = Profile.NewPassword;
                        }

                        _context.SaveChanges();
                        SuccessMessage = "Profile has been updated successfully.";
                    }
                }
            }

            return Page();
        }
    }

    public class UserProfile
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public string? NewPassword { get; set; }
    }
}
