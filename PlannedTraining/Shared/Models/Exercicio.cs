using System.ComponentModel.DataAnnotations.Schema;

namespace PlannedTraining.Shared.Models
{
    public class Exercicio : BaseEntity
    {
        public string Nome { get; set; }
        
        public string Descricao { get; set; }
        
        public int Series { get; set; }
        
        public int Repeticoes { get; set; }

        [ForeignKey("Treino")]
        public long TreinoId { get; set; }
    }
}
