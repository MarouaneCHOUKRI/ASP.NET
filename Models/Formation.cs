using System.ComponentModel.DataAnnotations;

namespace Universite.Models
{
    public class Formation
    {
        public int Id { get; set; }

        [Required]
        public string? Intitule { get; set; }

        [Required]
        public int? AnneeDiplome { get; set; }

        public ICollection<Etudiant>? EtudiantsInscrits { get; set; }

        [Display(Name = "Nombre d'inscrits")]
        public int NbInscrits
        {
            get
            {
                if (EtudiantsInscrits != null)
                
                    return EtudiantsInscrits.Count;
                
                else return -1;
            }
        }

        public ICollection<UE>? UeListe { get; set; }

        [Display(Name = "Nombre d'UEs")]
        public int NbUes
        {
            get
            {
                if (UeListe != null)

                    return UeListe.Count;

                else return -1;
            }
        }
    }
}
