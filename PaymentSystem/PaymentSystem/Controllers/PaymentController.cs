using System;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Models;

namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly DbHelper _db;

        public PaymentController(DbHelper db)
        {
            _db = db;
        }

        // GET api/payment/getsession
        [HttpGet("getsession")]
        public ActionResult<string> GetSession(double amount, string purpose = "")
        {
            var session = new Session(amount, purpose);
            _db.AddSession(session);
            return Ok(session.SessionId);
        }

        // GET api/payment/setpayment
        [HttpPost("setpayment")]
        public ActionResult Payment([FromBody]PaymentInformation info)
        {
            if (!info.AllNotNull())
                return BadRequest(info.Error);

            //достанем нужную информацию если нужно
            var session = _db.GetSession(info.Session_Id);

            if (!CheckLunh(info.Number))
                return BadRequest("Bad card number");

            if (session == null)
                return BadRequest("Bad session id");

            if (!info.Cvc.Length.Equals(3) || !int.TryParse(info.Cvc, out _))
                return BadRequest("Bad cvc");

            if (!DateTime.TryParse(info.Date, out _))
                return BadRequest("Bad date");

            //Имитация оплаты

            _db.DeleteSession(info.Session_Id);

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
