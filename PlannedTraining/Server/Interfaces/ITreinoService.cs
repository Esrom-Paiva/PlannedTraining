using PlannedTraining.Shared.Models;

namespace PlannedTraining.Server.Interfaces
{
    public interface ITreinoService
    {
        List<Treino> GetTreinosByData(DateTime data);

        Treino GetTreino(long id);
        
        void AddTreinos(List<Treino> treinos);
        
        void UpdateTreino(long idAluno);
        
        void ReativarTreino(long id);
        
        void DeleteTreino(long id);
    }
}
