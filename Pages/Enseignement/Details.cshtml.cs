using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universite.Data;
using Universite.Models;

namespace Universite.Pages.Enseignement
{
    public class DetailsModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public DetailsModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Enseigner Enseigner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Enseigner == null)
            {
                return NotFound();
            }

            var enseigner = await _context.Enseigner.FirstOrDefaultAsync(m => m.ID == id);
            if (enseigner == null)
            {
                return NotFound();
            }
            else 
            {
                Enseigner = enseigner;
            }
            return Page();
        }
    }
}
