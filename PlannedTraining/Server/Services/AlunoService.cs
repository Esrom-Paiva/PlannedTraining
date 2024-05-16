using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using PlannedTraining.Client.Pages.Alunos;
using PlannedTraining.Server.Context;
using PlannedTraining.Server.Interfaces;
using PlannedTraining.Shared.Models;

namespace PlannedTraining.Server.Services
{
    public class AlunoService: IAlunoService
    {
        private readonly BaseContext _context;

        public AlunoService(BaseContext baseContext)
        {
            _context = baseContext;
        }

        #region aluno
        public List<Aluno> GetAlunos()
        {
            try
            {
                return
                    _context.
                    Alunos.Where(x => x.RegistroAtivo == true)
                    .OrderByDescending(x => x.InseridoEm).ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Aluno> GetAlunosInativados()
        {
            try
            {
                return
                    _context.
                    Alunos.Where(x => x.RegistroAtivo == false)
                    .OrderByDescending(x => x.InseridoEm).ToList();
            }
            catch
            {
                throw;
            }
        }

        public Aluno GetAluno(long id)
        {
            try
            {
                var aluno = _context.Alunos
                    .Include(x => x.Endereco)
                    .Include(x => x.Treinos)
                    .ThenInclude(t => t.Exercicios)
                    .FirstOrDefault(x => x.Id == id && x.RegistroAtivo);

                return aluno;
            }
            catch
            {
                throw;
            }
        }

        public void AddAluno(Aluno aluno)
        {
            try
            {
                aluno.InseridoEm = DateTime.Now;
                aluno.ModificadoEm = DateTime.Now;

                aluno.Endereco.InseridoEm = DateTime.Now;
                aluno.Endereco.ModificadoEm = DateTime.Now;

                _context.Alunos.Add(aluno);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateAluno(Aluno aluno)
        {
            try
            {
                aluno.ModificadoEm = DateTime.Now;

                _context.Alunos.Update(aluno);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void ReativarAluno(long id)
        {
            try
            {
                var aluno = _context.Alunos
                    .Include(x => x.Endereco)
                    .FirstOrDefault(x => x.Id == id && !x.RegistroAtivo);

                aluno.RegistroAtivo = true;
                aluno.ModificadoEm = DateTime.Now;

                aluno.Endereco.RegistroAtivo = true;
                aluno.Endereco.ModificadoEm = DateTime.Now;

                _context.Alunos.Update(aluno);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteAluno(long id)
        {
            try
            {
                var aluno = GetAluno(id);

                if (aluno != null)
                {
                    aluno.RegistroAtivo = false;
                    aluno.Endereco.RegistroAtivo = false;

                    _context.Alunos.Update(aluno);
                    _context.SaveChanges();
                }
                else
                    throw new ArgumentNullException();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region treino
        public void DeleteTreino(long id)
        {
            try
            {
                var treino
                    = _context
                    .Treinos.FirstOrDefault(x => x.Id == id);

                if (treino is not null)
                {
                    treino.RegistroAtivo = false;
                    treino.ModificadoEm = DateTime.Now;

                    _context.Treinos.Update(treino);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteExercicio(long id)
        {
            try
            {
                var exercicio
                    = _context
                    .Exercicios.FirstOrDefault(x => x.Id == id);

                if (exercicio is not null)
                {
                    exercicio.RegistroAtivo = false;
                    exercicio.ModificadoEm = DateTime.Now;

                    _context.Exercicios.Update(exercicio);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Treino GetTreinoById(long id)
        {
            try
            {
                var treino
                    = _context
                    .Treinos.FirstOrDefault(x => x.Id == id);

                return treino;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AddTreino(Treino treino)
        {
            try
            {
                treino.InseridoEm = DateTime.Now;
                treino.ModificadoEm = DateTime.Now;

                treino.Exercicios.ForEach(treino =>
                {
                    treino.InseridoEm = DateTime.Now;
                    treino.ModificadoEm = DateTime.Now;
                });

                _context.Treinos.Add(treino);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void AddExercicio(List<Exercicio> exercicios)
        {
            try
            {
                exercicios.ForEach(treino =>
                {
                    treino.InseridoEm = DateTime.Now;
                    treino.ModificadoEm = DateTime.Now;
                });

                _context.Exercicios.AddRange(exercicios);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Pagamento
        public List<Mensalidade> GetMensalidadesByIdAluno(long idAluno)
        {
            var mensalidade = new List<Mensalidade>();

            mensalidade =
                _context.Mensalidades
                .Where(m => m.RegistroAtivo == true && m.AlunoId == idAluno)
                .OrderByDescending(x => x.InseridoEm)
                .ToList();

            return mensalidade;

        }
        public void AddPagamento(Mensalidade mensalidade)
        {
            try
            {
                mensalidade.InseridoEm = DateTime.Now;
                mensalidade.ModificadoEm = DateTime.Now;

                _context.Mensalidades.Add(mensalidade);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool VerificaSeExisteMensalidadePagaParaData(DateTime dataMensalidade, long idAluno)
         {
            try 
            {
                var mes = dataMensalidade.Month;

                var ano = dataMensalidade.Year;

                var mensalidade
                    = _context.Mensalidades
                    .Where(x => x.RegistroAtivo == true
                                  && x.AlunoId == idAluno
                                  && x.DataMensalidade.Month == mes
                                  && x.DataMensalidade.Year == ano);

                var result = mensalidade.Count();

                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteMensalidade(long id)
        {
            var mensalidade =
            _context.Mensalidades
                .FirstOrDefault(m => m.Id == id);

            if (mensalidade is not null)
            {
                mensalidade.RegistroAtivo = false;
                mensalidade.ModificadoEm = DateTime.Now;

                _context.Mensalidades.Update(mensalidade);
                _context.SaveChanges();
            }
        }
        #endregion
    }
}
