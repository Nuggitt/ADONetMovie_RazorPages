using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages.Pages.Studios
{
    public class UpdateModel : PageModel
    {
        private IStudioService _studioService;
        [BindProperty]
        public Studio Studio { get; set; }

        public UpdateModel(IStudioService studioService)
        {
            this._studioService = studioService;
        }

        public void OnGet(int id)
        {
            Studio = _studioService.GetStudio(id);
        }

        public IActionResult OnPost()
        {
            Studio = _studioService.UpdateStudio(Studio);
            return RedirectToPage("GetStudios");
        }
    }
}
