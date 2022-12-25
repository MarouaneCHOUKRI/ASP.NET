using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universite.Data;
using Universite.Models;

namespace Universite.Pages.Enseignants
{
    public class DetailsModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public DetailsModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

       public Enseignant Enseignant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Enseignant == null)
            {
                return NotFound();
            }

            //var enseignant = await _context.Enseignant.FirstOrDefaultAsync(m => m.Id == id);
            Enseignant = await _context.Enseignant.Include(i => i.LesEnseigner).ThenInclude(i => i.LUE).FirstOrDefaultAsync(m => m.Id == id);
            if (Enseignant == null)
            {
                return NotFound();
            }
            else 
            {
                Enseignant = Enseignant;
            }
            return Page();
        }
    }
}
