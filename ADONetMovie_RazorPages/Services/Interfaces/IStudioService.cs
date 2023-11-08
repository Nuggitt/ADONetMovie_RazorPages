using ADONetMovie_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.Interfaces
{
    public interface IStudioService
    {
        IEnumerable<Studio> GetStudios();

        Studio CreateStudio(Studio studio);


        Studio DeleteStudio(Studio studio);

        Studio GetStudio(int id);

        Studio UpdateStudio(Studio studio);


    }
}
