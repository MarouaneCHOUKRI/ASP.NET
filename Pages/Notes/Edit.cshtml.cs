using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Universite.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Universite.Pages.Notes
{
    [Authorize(Roles = "Enseignant")]
    
    public class EditModel : PageModel
    {
        private readonly Universite.Data.ApplicationDbContext _context;

        public EditModel(Universite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string form1 = "block";
        public string form2 = "none";
        public string titre = null;
        public int ueid = 0;
        public int FormationSuivie = 0;
        public string valeur;

        public List<Note> Noote = new List<Note>();
        public UE UE { get; set; }
        public Note note { get; set; }
        public List<Etudiant> etudiant = new List<Etudiant>();
        public Dictionary<string, string> lista = new Dictionary<string, string>();

        public async Task<IActionResult> OnGetAsync()
        {

            List<SelectListItem> items = new SelectList(
                               _context.UE,
                                "Id",
                                "Intitule"
                               ).ToList();

            items.Insert(0, (new SelectListItem
            {
                Text = "Choisir une UE",
                Value = "0",
                Selected = true
            }));

            ViewData["LUEID"] = new SelectList(items, "Value", "Text");

            return Page();
        }

        public async Task<IActionResult> OnPostChargeAsync(string query)
        {
            if (query != "0")
            {
                form1 = "none";
                form2 = "block";

                var ue = await _context.UE.FindAsync(Int32.Parse(query));

                titre = ue.Intitule;
                ueid = ue.Id;
                FormationSuivie = (int) ue.UeSuivieID;

                etudiant = await _context.Etudiant
                    .Where(e => e.FormationSuivieID == FormationSuivie)
                    .ToListAsync();

                foreach (var item in etudiant)
                {
                    Noote = await _context.Note
                        .Where(e => e.LEtudiantID == item.Id)
                        .Where(e => e.LUEID == ueid)
                        .ToListAsync();

                    var nomComplet = item.Nom + " " + item.Prenom;

                    foreach (var item2 in Noote)
                    {
                        lista.Add(item.Nom + " " + item.Prenom, item2.Valeur.ToString());
                    }


                    if (!lista.ContainsKey(nomComplet))
                    {
                        lista.Add(item.Nom + " " + item.Prenom, "ABS");
                    }
                }
            }
            else
            {
                return RedirectToPage("./Edit");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostEnregistreAsync(List<string> query, List<string> etudiantid, int ueid)
        {
            

            for (int i = 0; i < query.Count; i++)
            {
                Noote = await _context.Note
                            .Where(e => e.LEtudiantID == Int32.Parse(etudiantid[i]))
                            .Where(e => e.LUEID == ueid)
                            .ToListAsync();

                if (query[i] != "ABS")
                {
                    try
                    {
                        if (0.0 <= float.Parse(query[i]) && 20.0 >= float.Parse(query[i]))
                        {
                            if (!Noote.Any())
                            {
                                note = new Note
                                {
                                    Valeur = float.Parse(query[i]),
                                    LEtudiantID = Int32.Parse(etudiantid[i]),
                                    LUEID = ueid,
                                };

                                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Note ON;");
                                _context.Note.Add(note);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                float nbr;

                                foreach (var item2 in Noote)
                                {
                                    if (float.TryParse(query[i], out nbr))
                                    {
                                        item2.Valeur = nbr;
                                    }
                                    await _context.SaveChangesAsync();
                                }
                            }
                        }

                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Entre 0 et 20.");
                    }

                }
                else
                {
                    if (Noote.Any())
                    {
                        _context.Note.RemoveRange(Noote);
                        await _context.SaveChangesAsync();
                    }
                }

            }

            return RedirectToPage("./Edit");

        }
    }
}
