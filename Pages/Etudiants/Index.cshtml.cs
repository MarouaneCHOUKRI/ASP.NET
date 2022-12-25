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
    public class IndexModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public IndexModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Etudiant> Etudiant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Etudiant != null)
            {
                Etudiant = await _context.Etudiant
                .Include(e => e.FormationSuivie).ToListAsync();
            }
        }
    }
}
