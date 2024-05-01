using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlannedTraining.Shared.Models
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
       
        public DateTime InseridoEm { get; set; }
       
        public DateTime ModificadoEm { get; set; }
        
        public bool RegistroAtivo { get; set; } = true;
    }
}
