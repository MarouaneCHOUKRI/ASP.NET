using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Universite.Models;

namespace Universite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Etudiant> Etudiant { get; set;  }
        public DbSet<Note> Note { get; set; }
        public DbSet<Formation> Formation { get; set; }
        public DbSet<UE> UE { get; set; }
        public DbSet<Enseignant> Enseignant { get; set; }
        public DbSet<Universite.Models.Enseigner> Enseigner { get; set; }
    }
}