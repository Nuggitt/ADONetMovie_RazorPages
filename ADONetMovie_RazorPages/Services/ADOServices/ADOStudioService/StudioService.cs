
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.ADOStudioService
{
    public class StudioService :IStudioService
    {
         private AdonetStudioService studioService;
        public StudioService(AdonetStudioService service)
        {
            studioService = service;
        }
        public IEnumerable<Studio> GetStudios()
        {
            return studioService.GetAllStudios();
        }

        public Studio CreateStudio(Studio studio)
        {
            return studioService.CreateStudio(studio);
        }

        public Studio DeleteStudio(Studio studio)
        {
            return studioService.DeleteStudio(studio);
        }

        public Studio GetStudio(int id)
        {
            return studioService.GetStudio(id);
        }

        public Studio UpdateStudio(Studio studio)
        {
            return studioService.UpdateStudio(studio);
        }
    }
}
