using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universite.Data;
using Universite.Models;

namespace Universite.Pages.Ues
{
    public class DetailsModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public DetailsModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public UE UE { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UE == null)
            {
                return NotFound();
            }

            var ue = await _context.UE.FirstOrDefaultAsync(m => m.Id == id);
            if (ue == null)
            {
                return NotFound();
            }
            else 
            {
                UE = ue;
            }
            return Page();
        }
    }
}
