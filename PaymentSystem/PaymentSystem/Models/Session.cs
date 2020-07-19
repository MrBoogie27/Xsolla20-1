using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.Models
{
    public class Session
    {
        public string Session_id { get; }
        public double Amount { get; }
        public string Purpose { get; }
        public Session(double amount, string purpose)
        {
            Amount = amount;
            Purpose = purpose;
            Session_id = Guid.NewGuid().ToString();
        }
    }
}
