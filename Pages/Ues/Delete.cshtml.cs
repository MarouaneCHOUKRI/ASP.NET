using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Universite.Data;
using Universite.Models;

namespace Universite.Pages.Ues
{
    public class DeleteModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public DeleteModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UE == null)
            {
                return NotFound();
            }
            var ue = await _context.UE.FindAsync(id);
            var note = await _context.Note
                            .Where(e => e.LUEID == id)
                            .ToListAsync();

            if (ue != null)
            {
                UE = ue;
                _context.UE.Remove(UE);
                _context.Note.RemoveRange(note);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
