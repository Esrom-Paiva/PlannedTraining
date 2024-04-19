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

        Treino GetTreinoById(long id);

        void AddTreino(Treino treino);

        void DeleteAluno(long id);

        void DeleteTreino(long id);

        void DeleteExercicio(long id);
    }
}
