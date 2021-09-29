namespace ShopMarket.Core.Interfaces
{
    public interface IEmailSender
    {
        void Send(string to, string subject, string body);
    }
}