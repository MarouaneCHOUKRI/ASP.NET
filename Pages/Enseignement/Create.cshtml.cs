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
    public class CreateModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public Enseignant Enseignant { get; set; }

        [BindProperty]
        public Enseigner Enseigner { get; set; }

        public CreateModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id) 
        { 
            if (id == null) { return NotFound(); } 

            Enseignant = await _context.Enseignant.FirstOrDefaultAsync(m => m.Id == (int)id);

            ViewData["LUEID"] = new SelectList(_context.UE, "Id", "Intitule");
            
            return Page(); 
        }

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
          {
            return Page();
          }

          _context.Enseigner.Add(Enseigner);
          await _context.SaveChangesAsync();

          return RedirectToPage("../Enseignement/Index", new { id = Enseigner.LEnseignantID });
        }
    }
}
