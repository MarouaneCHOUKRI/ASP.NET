using System.ComponentModel.DataAnnotations;

namespace Universite.Models
{
    public class Enseignant
    {
        public int Id { get; set; }

        [Required]
        public string? Nom { get; set; }

        [Required]
        public string? Prenom { get; set; }

        [Display(Name = "UEs Enseignées")] 
        public ICollection<Enseigner>? LesEnseigner { get; set; }

        public string NomComplet { get { return Nom + " " + Prenom; } }
    }
}
