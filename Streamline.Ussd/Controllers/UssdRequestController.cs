using Microsoft.AspNetCore.Mvc;
using Streamline.Ussd.Models;
using System.Text.Json;

namespace Streamline.Ussd.Controllers
{
    [ApiController]
    [Route("api/ussd")]
    public class UssdRequestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<UssdRequestController> _logger;

        public UssdRequestController(ILogger<UssdRequestController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string Post([FromBody] UssdRequest incoming)
        {
            Console.WriteLine($"troll:{JsonSerializer.Serialize(incoming)}");
            var text = incoming.text;
            var response = "";

            if (string.IsNullOrEmpty(text) || text.ToLower().Equals("default"))
            {
                response = "CON What would you want to check \n";
                response += "1. My Account \n";
                response += "2. My phone number";
            }
            else if (text.Equals("1"))
            {
                response = "CON Choose account information you want to view \n";
                response += "1. Account number \n";
                response += "2. Account balance";
            }
            else if (text.Equals("1*1"))
            {
                var accountNumber = "G.R.A.C.E123";
                response = "END Your account number is " + accountNumber;
            }
            else if (text.Equals("1*2"))
            {
                var balance = "UGX 10,000";
                response = "END Your balance is " + balance;
            }

            else if (text.Equals("2"))
            {
                response = "END This is your phone number " + incoming.phoneNumber;

            }


            return response;
        }
    }
}