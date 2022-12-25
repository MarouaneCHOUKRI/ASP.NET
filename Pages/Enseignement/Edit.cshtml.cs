using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universite.Data;
using Universite.Models;

namespace Universite.Pages.Enseignement
{
    public class EditModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public EditModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enseigner Enseigner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Enseigner == null)
            {
                return NotFound();
            }

            var enseigner =  await _context.Enseigner.FirstOrDefaultAsync(m => m.ID == id);
            if (enseigner == null)
            {
                return NotFound();
            }
            Enseigner = enseigner;
           ViewData["LEnseignantID"] = new SelectList(_context.Enseignant, "Id", "Nom");
           ViewData["LUEID"] = new SelectList(_context.UE, "Id", "Intitule");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Enseigner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnseignerExists(Enseigner.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Enseignement/Index", new { id = Enseigner.LEnseignantID });
        }

        private bool EnseignerExists(int id)
        {
          return _context.Enseigner.Any(e => e.ID == id);
        }
    }
}
