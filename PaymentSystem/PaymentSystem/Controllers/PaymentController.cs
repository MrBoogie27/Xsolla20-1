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
        // GET api/payment/getsession
        [HttpGet("getsession")]
        public ActionResult<string> GetSession(double amount, string purpose = "")
        {
            var session = new Session(amount, purpose);
            return Ok(session.Session_id);
        }

        [HttpPost("setpayment")]
        public ActionResult Payment(string number, string cvc, string date, string session_id)
        {
            return Ok();
        }

    }
}
