using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universite.Data;
using Universite.Models;

namespace Universite.Pages.Formations
{
    [Authorize(Roles = "Administrateur")]

    public class DeleteModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public DeleteModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Formation Formation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Formation == null)
            {
                return NotFound();
            }

            var formation = await _context.Formation.FirstOrDefaultAsync(m => m.Id == id);

            if (formation == null)
            {
                return NotFound();
            }
            else 
            {
                Formation = formation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Formation == null)
            {
                return NotFound();
            }
            var formation = await _context.Formation.FindAsync(id);

            if (formation != null)
            {
                Formation = formation;
                _context.Formation.Remove(Formation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
