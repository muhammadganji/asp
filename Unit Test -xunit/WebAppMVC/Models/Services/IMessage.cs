namespace WebAppMVC.Models.Services
{
    public interface IMessage
    {
        void Sms(string message, int userId);
        void Email(string message, int userId);
        void Notif(string message, int userId);
    }

    public enum MessageType
    {
        Sms, Email, Notif
    }
}
