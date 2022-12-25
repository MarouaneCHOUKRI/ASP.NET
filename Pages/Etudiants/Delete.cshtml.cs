using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universite.Data;
using Universite.Models;

namespace Universite.Pages.Etudiants
{
    public class DeleteModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public DeleteModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Etudiant Etudiant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Etudiant == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiant.FirstOrDefaultAsync(m => m.Id == id);

            if (etudiant == null)
            {
                return NotFound();
            }
            else 
            {
                Etudiant = etudiant;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Etudiant == null)
            {
                return NotFound();
            }
            var etudiant = await _context.Etudiant.FindAsync(id);

            if (etudiant != null)
            {
                Etudiant = etudiant;
                _context.Etudiant.Remove(Etudiant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
