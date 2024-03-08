using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Utilidades.EmailManager
{
    /// <summary>
    /// Clase manejadora de email
    /// </summary>
    public class Sender
    {
        #region Propiedades de la clase

        string EmailFrom { get; set; }
        string Password { get; set; }
        string SmtpServer { get; set; }
        int Port { get; set; }
        bool ReqAut { get; set; }
        bool ReqSsl { get; set; }
        string Remitter { get; set; }

        System.Net.Mail.SmtpClient SmtpClient { get; set; }

        #endregion

        #region Constructores de la clase

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="emailfrom">Correo remitente</param>
        /// <param name="password">Contraseña</param>
        /// <param name="smtpserver">Servidor SMTP</param>
        /// <param name="port">Puerto</param>
        public Sender(string emailfrom, string password, string smtpserver, int port)
        {
            this.EmailFrom = emailfrom;
            this.Password = password;
            this.SmtpServer = smtpserver;
            this.Port = port;

            this.Remitter = string.Empty;
            this.ReqAut = false;
            this.ReqSsl = false;

            this.InitEmail();
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="emailfrom">Correo remitente</param>
        /// <param name="password">Contraseña</param>
        /// <param name="smtpserver">Servidor SMTP</param>
        /// <param name="port">Puerto</param>
        /// <param name="remitter">Remitente</param>
        public Sender(string emailfrom, string password, string smtpserver, int port, string remitter)
        {
            this.EmailFrom = emailfrom;
            this.Password = password;
            this.SmtpServer = smtpserver;
            this.Port = port;
            this.Remitter = remitter;

            this.ReqAut = false;
            this.ReqSsl = false;

            this.InitEmail();
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="emailfrom">Correo remitente</param>
        /// <param name="password">Contraseña</param>
        /// <param name="smtpserver">Servidor SMTP</param>
        /// <param name="port">Puerto</param>
        /// <param name="reqaut">Requiere autenticación</param>
        /// <param name="reqssl">Requiere SSL</param>
        /// <param name="remitter">Remitente</param>
        public Sender(string emailfrom, string password, string smtpserver, int port, bool reqaut, bool reqssl, string remitter)
        {
            this.EmailFrom = emailfrom;
            this.Password = password;
            this.SmtpServer = smtpserver;
            this.Port = port;
            this.ReqAut = reqaut;
            this.ReqSsl = reqssl;
            this.Remitter = remitter;

            this.InitEmail();
        }

        /// <summary>
        /// Inicializa el cliente SMTP
        /// </summary>
        void InitEmail()
        {
            this.SmtpClient = new System.Net.Mail.SmtpClient();
            if (this.ReqAut)
                this.SmtpClient.Credentials = new System.Net.NetworkCredential(this.EmailFrom, this.Password);

            this.SmtpClient.Host = this.SmtpServer;
            this.SmtpClient.Port = this.Port;
            this.SmtpClient.EnableSsl = this.ReqSsl;
        }

        #endregion

        /// <summary>
        /// Envia mensaje de correo
        /// </summary>
        /// <param name="message">Mensaje</param>
        /// <param name="toemail">Destinatario</param>
        public void SendEmailMessage(CustomEmailMessage message, string toemail)
        {
            this.SendEmailMessage("Email message", message, new string[] { toemail }, null);
        }

        /// <summary>
        /// Envia mensaje de correo
        /// </summary>
        /// <param name="subject">Asunto de correo</param>
        /// <param name="message">Mensaje</param>
        /// <param name="toemail">Destinatario</param>
        public void SendEmailMessage(string subject, CustomEmailMessage message, string toemail)
        {
            this.SendEmailMessage(subject, message, new string[] { toemail }, null);
        }

        /// <summary>
        /// Envia mensaje de correo
        /// </summary>
        /// <param name="subject">Asunto de correo</param>
        /// <param name="message">Mensaje</param>
        /// <param name="toemail">Destinatario</param>
        /// <param name="tohideemail">Correo de copia oculta</param>
        public void SendEmailMessage(string subject, CustomEmailMessage message, string toemail, string tohideemail)
        {
            this.SendEmailMessage(subject, message, new string[] { toemail }, new string[] { tohideemail });
        }

        /// <summary>
        /// Envia mensaje de correo
        /// </summary>
        /// <param name="subject">Asunto de correo</param>
        /// <param name="message">Mensaje</param>
        /// <param name="toemail">Destinatario</param>
        /// <param name="toemails">Destinatarios</param>
        /// <param name="tohideemails">Copias ocultas</param>
        public void SendEmailMessage(string subject, CustomEmailMessage message, string[] toemails, string[] tohideemails)
        {
            System.Net.Mail.MailMessage mailmessage = new System.Net.Mail.MailMessage();
            if (!string.IsNullOrWhiteSpace(this.Remitter))
                mailmessage.From = new System.Net.Mail.MailAddress(this.EmailFrom, this.Remitter);
            else
                mailmessage.From = new System.Net.Mail.MailAddress(this.EmailFrom);

            mailmessage.Subject = subject;
            mailmessage.Body = string.Empty;
            mailmessage.IsBodyHtml = true;

            System.Net.Mail.AlternateView html = System.Net.Mail.AlternateView.CreateAlternateViewFromString(message.HtmlMessage, null, "text/html");
            if (message.MessageImages.Count() > 0)
            {
                foreach (var img in message.MessageImages.ToArray())
                {
                    byte[] barray = Convert.FromBase64String(img.b64imagem);

                    System.IO.Stream stream = new System.IO.MemoryStream(barray);
                    System.Net.Mail.LinkedResource imglnk = new System.Net.Mail.LinkedResource(stream);
                    imglnk.ContentId = img.cid;
                    imglnk.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                    html.LinkedResources.Add(imglnk);
                }
            }
            mailmessage.AlternateViews.Add(html);

            if (toemails != null)
            {
                foreach (string m in toemails)
                    mailmessage.To.Add(m);
            }
            if (tohideemails != null)
            {
                foreach (string m in tohideemails)
                    mailmessage.Bcc.Add(m);
            }

            if (message.AttachmentFiles.Count() > 0)
            {
                foreach (var file in message.AttachmentFiles.ToArray())
                {
                    byte[] barray = Convert.FromBase64String(file.fileb64data);

                    System.IO.Stream stream = new System.IO.MemoryStream(barray);
                    System.Net.Mail.Attachment attachmet = new System.Net.Mail.Attachment(stream, file.filename);
                    mailmessage.Attachments.Add(attachmet);
                }
            }

            this.SmtpClient.Send(mailmessage);
        }
    }
}
