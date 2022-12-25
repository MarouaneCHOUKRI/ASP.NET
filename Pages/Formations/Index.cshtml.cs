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
    [Authorize(Roles = "Administrateur, Enseignant")]

    public class IndexModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public IndexModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Formation> Formation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Formation != null)
            {
                Formation = await _context
                    .Formation
                    .Include(e => e.EtudiantsInscrits)
                    .Include(e => e.UeListe)
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
    }
}
