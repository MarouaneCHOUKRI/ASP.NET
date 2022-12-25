using System.ComponentModel.DataAnnotations;

namespace Universite.Models
{
    public class Etudiant
    {
        public int Id { get; set; }

        [Required]
        public string? Nom { get; set; }

        [Required]
        public string? Prenom { get; set; }

        [Required]
        public DateTime? Naissance { get; set; }

        [Required]
        public string? NumeroEtudiant { get; set; }

        public int? FormationSuivieID { get; set; } 
        
        public Formation? FormationSuivie { get; set; }

    }
}
