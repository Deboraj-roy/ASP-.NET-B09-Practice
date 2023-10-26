namespace FirstDemo.Web.Models
{
    public interface ISmsSender
    {
        void SendSms(string moblie, string message);
    }
}
