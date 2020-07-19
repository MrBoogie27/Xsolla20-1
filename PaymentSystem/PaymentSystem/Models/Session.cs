using System;

namespace PaymentSystem.Models
{
    public class Session
    {
        public string SessionId { get; }
        public double Amount { get; }
        public string Purpose { get; }
        public Session(double amount, string purpose)
        {
            Amount = amount;
            Purpose = purpose;
            SessionId = Guid.NewGuid().ToString();
        }
    }
}
