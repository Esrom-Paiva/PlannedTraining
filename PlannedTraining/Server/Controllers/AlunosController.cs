using Microsoft.AspNetCore.Mvc;
using PlannedTraining.Server.Interfaces;
using PlannedTraining.Shared.Models;
using System.Globalization;

namespace PlannedTraining.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        #region alunos
        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return _alunoService.GetAlunos();
        }

        [HttpGet("{id}")]
        public Aluno Get(long id)
        {
            return _alunoService.GetAluno(id);
        }

        [HttpGet("reativar")]
        public IEnumerable<Aluno> GetAlunosInativados()
        {
            return _alunoService.GetAlunosInativados();
        }


        [HttpPost("reativar/{id}")]
        public void ReativarAluno(long id)
        {
            _alunoService.ReativarAluno(id);

        }

        [HttpPost]
        public void Post(Aluno aluno)
        {
            _alunoService.AddAluno(aluno);
        }

        [HttpPut]
        public void Put(Aluno aluno)
        {
            _alunoService.UpdateAluno(aluno);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _alunoService.DeleteAluno(id);
        }
        #endregion

        #region Treinos
        [HttpGet("treino/{id}")]
        public void GetTreino(long id)
        {
            _alunoService.GetTreinoById(id);
        }

        [HttpPost("treino")]
        public void PostTreino(Treino treino)
        {
            _alunoService.AddTreino(treino);
        }

        [HttpPost("exercicio")]
        public void PostExercicio(List<Exercicio> exercicio)
        {
            _alunoService.AddExercicio(exercicio);
        }

        [HttpDelete("treino/{id}")]
        public void DeleteTreino(long id)
        {
            _alunoService.DeleteTreino(id);
        }

        [HttpDelete("exercicio/{id}")]
        public void DeleteExercicio(long id)
        {
            _alunoService.DeleteExercicio(id);
        }
        #endregion

        #region Pagamentos
        [HttpGet("mensalidade/MensalidadesByIdAluno/{idAluno}")]
        public List<Mensalidade> GetMensalidadesByIdAluno(long idAluno)
        {
            return _alunoService.GetMensalidadesByIdAluno(idAluno);
        }

        [HttpPost("mensalidade")]
        public void SalvarPagamento(Mensalidade mensalidade)
        {
            _alunoService.AddPagamento(mensalidade);
        }

        [HttpGet("mensalidade/VerificaSeExisteMensalidadePagaParaData/{data}/{idAluno}")]
        public bool VerificaSeExisteMensalidadePagaParaData(string data, long idAluno)
        {
            var dataMens = DateTime.ParseExact(data, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return _alunoService.VerificaSeExisteMensalidadePagaParaData(dataMens, idAluno);
        }

        [HttpDelete("mensalidade/DeleteMensalidade/{id}")]
        public void DeleteMensalidade(long id)
        {
            _alunoService.DeleteMensalidade(id);
        }
        #endregion
    }
}
