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
    public class DeleteModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public DeleteModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Enseignant Enseignant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Enseignant == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignant.FirstOrDefaultAsync(m => m.Id == id);

            if (enseignant == null)
            {
                return NotFound();
            }
            else 
            {
                Enseignant = enseignant;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Enseignant == null)
            {
                return NotFound();
            }
            var enseignant = await _context.Enseignant.FindAsync(id);

            if (enseignant != null)
            {
                Enseignant = enseignant;
                _context.Enseignant.Remove(Enseignant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
