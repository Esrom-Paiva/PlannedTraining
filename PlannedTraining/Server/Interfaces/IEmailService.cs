namespace PlannedTraining.Server.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string nomeAluno, string email, decimal valorPago, DateTime dataMensalidade);
    }
}
