using PlannedTraining.Shared.Models;

namespace PlannedTraining.Server.Interfaces
{
    public interface IAlunoService
    {
        #region aluno
        List<Aluno> GetAlunos();

        Aluno GetAluno(long id);

        List<Aluno> GetAlunosInativados();

        void AddAluno(Aluno aluno);

        void UpdateAluno(Aluno aluno);

        void ReativarAluno(long id);

        void DeleteAluno(long id);
        #endregion

        #region treino
        Treino GetTreinoById(long id);

        void AddTreino(Treino treino);

        void AddExercicio(List<Exercicio> exercicios);

        void DeleteTreino(long id);

        void DeleteExercicio(long id);
        #endregion
    }
}
