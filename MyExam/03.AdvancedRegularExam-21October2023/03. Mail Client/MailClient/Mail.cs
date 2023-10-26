using System.Reflection;
using System.Text;

namespace MailClient
{
    public class Mail
    {
        public Mail(string sender, string receiver, string body)
        {
            Sender = sender;
            Receiver = receiver;
            Body = body;
        }

        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Body { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"From: {Sender} / To: {Receiver}");
            stringBuilder.AppendLine($"Message: {Body}");


            return stringBuilder.ToString().TrimEnd();
        }
    }
}
