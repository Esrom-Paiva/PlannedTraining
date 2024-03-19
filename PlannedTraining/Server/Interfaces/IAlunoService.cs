using PlannedTraining.Shared.Models;

namespace PlannedTraining.Server.Interfaces
{
    public interface IAlunoService
    {
        List<Aluno> GetAlunos();
        Aluno GetAluno(long id);

        void AddAluno(Aluno aluno);

        void UpdateAluno(Aluno aluno);

        void DeleteAluno(long id);
    }
}
