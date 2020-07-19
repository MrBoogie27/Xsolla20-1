using System.Text;

namespace PaymentSystem.Models
{
    public class PaymentInformation
    {
        public string Number, Cvc, Date, Session_Id;
        public string Error { get; private set; }
        public bool AllNotNull()
        {
            var error = new StringBuilder();
            if (Number == null)
                error.Append("number is null;");
            if (Cvc == null)
                error.Append("cvc is null;");
            if (Date == null)
                error.Append("date is null;");
            if (Session_Id == null)
                error.Append("session_id is null;");
            if (error.Length != 0)
            {
                Error = error.ToString();
                return false;
            }
            return true;
        }
    }
}
