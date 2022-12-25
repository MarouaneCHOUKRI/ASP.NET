namespace Universite.Models
{
    public class Enseigner
    {  
        public int ID { get; set; } 
        
        public int LEnseignantID {get; set;} 
        public Enseignant? LEnseignant { get; set; } 
        
        public int LUEID { get; set; } 
        public UE? LUE { get; set; } 
    
    }
}
