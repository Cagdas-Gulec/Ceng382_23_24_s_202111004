using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reservation.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UniversityReservationSystemContext _context;

        public LoginModel(UniversityReservationSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginInput Input { get; set; } = new LoginInput();

        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == Input.Username && u.Password == HashPassword(Input.Password));
                if (user != null)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    ErrorMessage = "Username/password is incorrect.";
                }
            }

            return Page();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }

    public class LoginInput
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
