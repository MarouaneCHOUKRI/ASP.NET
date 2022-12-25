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

    public class DetailsModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public DetailsModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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

                var etudiant = _context.Etudiant.Where(e => e.FormationSuivieID == formation.Id).ToList();

                var ue = _context.UE.Where(e => e.UeSuivieID == formation.Id).ToList();

                Formation.EtudiantsInscrits = etudiant;

                Formation.UeListe = ue;

            }

            return Page();
        }
    }
}
