using PlannedTraining.Shared.Models;

namespace PlannedTraining.Server.Interfaces
{
    public interface IAlunoService
    {
        List<Aluno> GetAlunos();
        Aluno GetAluno(long id);

        List<Aluno> GetAlunosInativados();

        void AddAluno(Aluno aluno);

        void UpdateAluno(Aluno aluno);

        void ReativarAluno(long id);

        void DeleteAluno(long id);
    }
}
