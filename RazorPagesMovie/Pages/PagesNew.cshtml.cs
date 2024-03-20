using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class PagesNewModel : PageModel
    {

        private readonly ILogger<MyApp.Namespace.PagesNewModel> _logger;

        public PagesNewModel(ILogger<PagesNewModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
