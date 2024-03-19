using Microsoft.EntityFrameworkCore;
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
        public Aluno GetAluno(long id)
        {
            try
            {
                var aluno = _context.Alunos
                    .Include(x => x.Endereco)
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
    }
}
