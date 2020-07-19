using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Models;

namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        readonly DbHelper db;

        public PaymentController(DbHelper db)
        {
            this.db = db;
        }

        // GET api/payment/getsession
        [HttpGet("getsession")]
        public ActionResult<string> GetSession(double amount, string purpose = "")
        {
            var session = new Session(amount, purpose);
            db.AddSession(session);
            return Ok(session.Session_id);
        }

        // GET api/payment/setpayment
        [HttpPost("setpayment")]
        public ActionResult Payment([FromBody]PaymentInformation info)
        {
            if (!info.AllNotNull())
                return BadRequest(info.Error);

            //достанем нужную информацию если нужно
            var session = db.GetSession(info.session_id);

            if (!CheckLunh(info.number))
                return BadRequest("Bad card number");

            if (session == null)
                return BadRequest("Bad session id");

            if (!info.cvc.Length.Equals(3) || !int.TryParse(info.cvc, out int _))
                return BadRequest("Bad cvc");

            if (!DateTime.TryParse(info.date, out DateTime _))
                return BadRequest("Bad date");

            //Имитация оплаты

            db.DeleteSession(info.session_id);

            return Ok();
        }

        private bool CheckLunh(string number)
        {
            int sum = 0;
            int n = number.Length;

            int parity = n % 2;

            for (int i = 0; i < n; i++)
            {
                int digit = number[i] - '0';

                if (i % 2 == parity)
                {
                    digit = digit * 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
            }
            return 0 == sum % 10;
        }

    }
}
