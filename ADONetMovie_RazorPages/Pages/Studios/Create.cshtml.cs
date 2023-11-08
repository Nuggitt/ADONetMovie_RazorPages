using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages.Pages.Studios
{
    public class CreateModel : PageModel
    {
        private IStudioService studioService;

        [BindProperty]
        public Studio Studio { get; set; }
        public CreateModel(IStudioService sService)
        {
            studioService = sService;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Studio = studioService.CreateStudio(Studio);
            return RedirectToPage("GetStudios");
        }


    }
}
