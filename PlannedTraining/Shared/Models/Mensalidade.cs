using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlannedTraining.Shared.Models
{
    public class Mensalidade : BaseEntity
    {
        public decimal ValorPago { get; set; }

        public DateTime DataPagamento { get; set; }

        public DateTime DataMensalidade { get; set; }

        [ForeignKey("Aluno")]
        public long AlunoId { get; set; }
    }
}
