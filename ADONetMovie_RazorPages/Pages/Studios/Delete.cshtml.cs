using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Collections.Generic;

namespace ADONetMovie_RazorPages.Pages.Studios
{
    public class DeleteModel : PageModel
    {
        private IStudioService _studioService;

        [BindProperty]
        public Studio Studio { get; set; }

        public IEnumerable<Studio> Studios { get; set; } = new List<Studio>();

        public DeleteModel(IStudioService studioService)
        {
            _studioService = studioService;
        }

        public void OnGet(int id)
        {
            Studio  = _studioService.GetStudio(id);
        }

        public IActionResult OnPost()
        {
           
            Studio = _studioService.DeleteStudio(Studio);
            return RedirectToPage("GetStudios");
        }
    }
}
