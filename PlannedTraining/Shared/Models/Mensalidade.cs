using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace PlannedTraining.Shared.Models
{
    public class Mensalidade : BaseEntity
    {
        public decimal ValorPago { get; set; }

        public decimal DataPagamento { get; set; }

        [ForeignKey("Treino")]
        public Aluno AlunoId { get; set; }
    }
}
