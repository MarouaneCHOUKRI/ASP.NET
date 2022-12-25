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

namespace Universite.Pages.Ues
{
    public class IndexModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public IndexModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UE> UE { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UE != null)
            {
                UE = await _context.UE
                .Include(u => u.UeSuivie).ToListAsync();
            }
        }
    }
}
