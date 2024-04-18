using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedTraining.Shared.Models
{
    public class Treino : BaseEntity
    {
        public DateTime DataTreino { get; set; }
        public List<Exercicio> Exercicios { get; set; }
        
        [ForeignKey("Aluno")]
        public long AlunoId { get; set; }

    }
}
