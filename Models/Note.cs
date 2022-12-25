using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Universite.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public float Valeur { get; set; }

        public int LEtudiantID { get; set; }
        public Etudiant? LEtudiant { get; set; }

        public int LUEID { get; set; }
        public UE? LUE { get; set; }

    }
}
