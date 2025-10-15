using System;
using System.Net;
using System.Net.Mail;

namespace Hospital_sanVicente.Utils
{
    public class EmailSender
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            // Credenciales de Mailtrap (valores proporcionados por ti)
            string smtpServer = "sandbox.smtp.mailtrap.io";  // Servidor SMTP de Mailtrap
            int smtpPort = 2525;                             // Puerto SMTP de Mailtrap (2525 es común)
            string smtpUsername = "21040afaca8e84";          // nombre de usuario Mailtrap
            string smtpPassword = "79bca208922c1d";                 // contraseña Mailtrap (recuerda usar tu contraseña real)

            try
            {
                // Crear el objeto SmtpClient con la configuración de Mailtrap
                using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(smtpUsername, smtpPassword);  // Autenticación
                    smtp.EnableSsl = true;  // Habilitar SSL para seguridad

                    // Crear el mensaje de correo
                    MailMessage message = new MailMessage("noreply@tuhospital.com", toEmail, subject, body);

                    // Enviar el correo
                    smtp.Send(message);

                    Console.WriteLine("Email sent successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
