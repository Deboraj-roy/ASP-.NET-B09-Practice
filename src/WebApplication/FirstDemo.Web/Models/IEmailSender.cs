namespace FirstDemo.Web.Models
{
    public interface IEmailSender
    {
        void SendEmail(string ReceverEmail, string subject, string body);
    }
}
