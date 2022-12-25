using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universite.Data;
using Universite.Data.Migrations;
using Universite.Models;

namespace Universite.Pages.Enseignement
{
    public class DeleteModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public DeleteModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Enseigner == null)
            {
                return NotFound();
            }
            var enseigner = await _context.Enseigner.FindAsync(id);

            if (enseigner != null)
            {
                Enseigner = enseigner;
                _context.Enseigner.Remove(Enseigner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Enseignement/Index", new { id = Enseigner.LEnseignantID });
        }
    }
}
