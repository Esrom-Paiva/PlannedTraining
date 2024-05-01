using System.ComponentModel.DataAnnotations.Schema;

namespace PlannedTraining.Shared.Models
{
    public class Treino : BaseEntity
    {
        public DateTime DataTreino { get; set; }
        
        public string NomeTreino { get; set; }
       
        public List<Exercicio> Exercicios { get; set; }
        
        [ForeignKey("Aluno")]
        public long AlunoId { get; set; }
    }
}
