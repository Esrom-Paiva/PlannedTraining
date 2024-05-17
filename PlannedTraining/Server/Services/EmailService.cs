using System.Text;
using System.Net.Mail;
using PlannedTraining.Shared.Enuns;
using PlannedTraining.Server.Interfaces;
namespace PlannedTraining.Server.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string nomeAluno,string email, decimal valorPago, DateTime dataMensalidade)
        {
            var emailDeEnvio = "xxxxxxx";

            var mailMessage = MontaEmail(nomeAluno, emailDeEnvio, email, valorPago, dataMensalidade);

            DispararEmail(emailDeEnvio, mailMessage);
        }

        private static MailMessage MontaEmail(string nomeAluno, string emailDeEnvio, string email, decimal valorPago, DateTime dataMensalidade)
        {
            var mailMessage = new MailMessage();

            var mesPorExtenso = Enum.GetName(typeof(Meses), dataMensalidade.Month);

            mailMessage.From = new MailAddress(emailDeEnvio);

            mailMessage.To.Add(new MailAddress(email));

            mailMessage.Subject = $"Pagamento da Mensalidade do mês {mesPorExtenso} de {dataMensalidade.Year}";

            var body = new StringBuilder().AppendLine($"Prezado aluno {nomeAluno}");
            body.AppendLine($"Recebemos o pagamento no valor de R$ {valorPago}, referente a Mensalidade do mês {mesPorExtenso} de {dataMensalidade.Year}");
            body.AppendLine("Agradecemos a preferência");
            body.AppendLine("Atenciosamente,");
            body.AppendLine("Planned Training,");

            mailMessage.Body = body.ToString();
            mailMessage.IsBodyHtml = false;

            return mailMessage;
        }

        private static void DispararEmail(string emailDeEnvio, MailMessage mailMessage)
        {
            using var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(emailDeEnvio, "xxxxxx");

            smtp.Send(mailMessage);
        }
    }
}
