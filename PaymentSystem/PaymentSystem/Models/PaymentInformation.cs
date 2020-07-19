using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Models
{
    public class PaymentInformation
    {
        public string number, cvc, date, session_id;
        public string Error { get; private set; }
        public bool AllNotNull()
        {
            var error = new StringBuilder();
            if (number == null)
                error.Append("numer is null;");
            if (cvc == null)
                error.Append("cvc is null;");
            if (date == null)
                error.Append("date is null;");
            if (session_id == null)
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
