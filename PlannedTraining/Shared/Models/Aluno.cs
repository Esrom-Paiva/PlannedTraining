using PlannedTraining.Shared.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlannedTraining.Shared.Models
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; } = null!;

        public DateTime DataNascimento { get; set; }

        public Genero Genero { get; set; }

        public Endereco Endereco { get; set; }

        public string Telefone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public List<Treino> Treinos { get; set; }

        [NotMapped]
        public int Idade
        { get { return DateTime.Now.Year - DataNascimento.Year; } }
    }
}
