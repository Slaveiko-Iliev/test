using System.Text;
using System.Text.RegularExpressions;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public int Capacity { get; private set; }
        public List<Mail> Inbox { get; private set; }
        public List<Mail> Archive { get; private set; }

        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count < Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            return Inbox.Remove(Inbox.FirstOrDefault(m => m.Sender == sender));
        }

        public int ArchiveInboxMessages()
        {
            int count = Inbox.Count;

            foreach (var mail in Inbox)
            {
                Archive.Add(mail);
            }

            Inbox.Clear();

            return count;
        }

        public string GetLongestMessage()
        {
            List<Mail> allMail = new List<Mail>();

            foreach (var mail in Inbox)
            {
                allMail.Add(mail);
            }

            foreach (var mail in Archive)
            {
                allMail.Add(mail);
            }

            return allMail.MaxBy(m => m.Body).ToString();
        }

        public string InboxView()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Inbox:");

            foreach (var mail in Inbox)
            {
                stringBuilder.AppendLine(mail.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
