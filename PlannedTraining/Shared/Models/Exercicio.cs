using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedTraining.Shared.Models
{
    public class Exercicio : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [ForeignKey("Treino")]
        public long TreinoId { get; set; }
    }
}
