using System;
using Jeeb.Client.Common;
using Jeeb.Client.Demo.Settings;
using Jeeb.Client.Demo.Utils;
using Jeeb.Client.Dtos;
using Jeeb.Client.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Jeeb.Client.Demo.Controllers
{
    public class CallbackController : Controller
    {
        private readonly IJeebPaymentClient _paymentClient;
        private readonly JeebSetting _jeebSetting;
        private readonly ILogger<HomeController> _logger;

        public CallbackController(IJeebPaymentClient paymentClient,
            IOptions<JeebSetting> jeebOptions,
            ILogger<HomeController> logger)
        {
            _paymentClient = paymentClient;
            _jeebSetting = jeebOptions.Value;
            _logger = logger;
        }
        
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult Index([FromQuery(Name = "hash")] string hash, [FromForm] CallbackDto data)
        {
            if (!SecurityTools.VerifyPaymentHash(_jeebSetting.ApiKey, data.OrderNo, hash))
                return Unauthorized();

            if (data.State == Constants.PaymentState.Expired)
            {
                return View(data);
                // No transaction has occurred. it was either canceled or expiration due has passed. Display the corresponding view.  
            }
            else if (data.State == Constants.PaymentState.PendingConfirmation)
            {
                // Payment has occurred and Jeeb is waiting for network/external confirmations.
                if (!data.Refund)
                {
                    // Refund flag is OFF. It means that rejection conditions haven't met.
                    // So the payment will be "Completed" after obtaining the required network/external confirmations.
                    // Display the corresponding view.
                    return View(data);
                }
                else
                {
                    // Refund flag is ON. It means that rejection conditions have met.
                    // So the payment will be "Rejected" after obtaining the required network/external confirmations.
                    // Display the corresponding view.
                    return View(data);
                }
            }
            else
            {
                // Payment has been failed on Jeeb. please contact Jeeb's support team.
                throw new Exception();
            }
        }
    }
}