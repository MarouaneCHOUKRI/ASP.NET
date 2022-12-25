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
    public class IndexModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public IndexModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Enseigner> Enseigner { get;set; }
        public int EnseignantID { get; set; }
        public Enseignant Enseignant { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null) { return NotFound(); }

            EnseignantID = (int)id;

            Enseignant = _context.Enseignant.Find(id);

            Enseigner = await _context.Enseigner.Include(e => e.LEnseignant).Where(e => e.LEnseignantID == id).Include(e => e.LUE).ToListAsync();

            if (Enseigner == null) { return NotFound(); }

            return Page();
        }
    }
}
