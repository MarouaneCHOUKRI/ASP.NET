using System.ComponentModel.DataAnnotations;

namespace Universite.Models
{
    public class UE
    {
        public int Id { get; set; }

        [Required]
        public string? Numero { get; set; }

        [Required]
        public string? Intitule { get; set; }

        public int? UeSuivieID { get; set; }

        public Formation? UeSuivie { get; set; }

        public string NomComplet { get { return Numero + " - " + Intitule; } }

        [Display(Name = "Enseignants de l’UE")] 
        public ICollection<Enseigner>? LesEnseigner { get; set; }
    }
}
