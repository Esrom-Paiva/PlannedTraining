using System.ComponentModel.DataAnnotations.Schema;

namespace PlannedTraining.Shared.Models
{
    public class Endereco : BaseEntity
    {
        public string Rua { get; set; } = string.Empty;
        
        public int Numero { get; set; }
       
        public string Complemento { get; set; } = string.Empty;
        
        public string Bairro { get; set; } = string.Empty;
        
        public string Cidade { get; set; } = string.Empty;
        
        public string Estado { get; set; } = string.Empty;
        
        public string Cep { get; set; } = string.Empty;     

        [ForeignKey("Aluno")]
        public long AlunoId { get; set; }
    }
}
