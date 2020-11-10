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
    public class WebhookController : Controller
    {
        private readonly IJeebPaymentClient _paymentClient;
        private readonly JeebSetting _jeebSetting;
        private readonly ILogger<HomeController> _logger;

        public WebhookController(IJeebPaymentClient paymentClient,
            IOptions<JeebSetting> jeebOptions,
            ILogger<HomeController> logger)
        {
            _paymentClient = paymentClient;
            _jeebSetting = jeebOptions.Value;
            _logger = logger;
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Index([FromQuery(Name = "hash")] string hash, [FromBody] WebhookDto data)
        {
            if (string.IsNullOrEmpty(hash) ||
                string.IsNullOrEmpty(data?.OrderNo) ||
                !SecurityTools.VerifyPaymentHash(_jeebSetting.ApiKey, data.OrderNo, hash))
                return Unauthorized();

            switch (data.State)
            {
                case Constants.PaymentState.PendingTransaction:
                    // It means that Jeeb is waiting for a transaction on any given payment details.
                    break;
                case Constants.PaymentState.PendingConfirmation:
                    // It means that a transaction on a specific payment detail has occurred and Jeeb is waiting for network/external confirmations.
                    break;
                case Constants.PaymentState.Completed:
                    // It means that a transaction has confirmed and we can seal the payment.

                    try
                    {
                        var result = _paymentClient.Seal(new SealDto
                        {
                            Token = data.Token
                        });
                        if (result.IsSealed)
                        {
                            // Payment has been sealed by the merchant successfully so we are safe to close the order.
                        }
                        else
                        {
                            throw new Exception("Unable to seal the payment");
                        }
                    }
                    catch (Exception e)
                    {
                        // Probably a double-spending attempt has occurred. For security reasons log the HTTP request details. Otherwise, we can skip.
                    }

                    break;
                case Constants.PaymentState.Expired:
                    // No transaction has occurred. it was either canceled or expiration due has passed. Display the corresponding view.
                    break;
                case Constants.PaymentState.Rejected:
                    // A transaction has occurred but rejection conditions have met.
                    break;
                case Constants.PaymentState.Failed:
                    // Payment has been failed on Jeeb. please contact Jeeb's support team.
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Ok(); // Always return OK.
        }
    }
}