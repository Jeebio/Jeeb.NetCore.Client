using System;
using System.Collections.Generic;
using System.Diagnostics;
using Jeeb.Client.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Jeeb.Client.Demo.Models;
using Jeeb.Client.Demo.Settings;
using Jeeb.Client.Demo.Utils;
using Jeeb.Client.Dtos;
using Jeeb.Client.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace Jeeb.Client.Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJeebPaymentClient _paymentClient;
        private readonly AppSetting _appSetting;
        private readonly JeebSetting _jeebSetting;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IJeebPaymentClient paymentClient,
            IOptions<AppSetting> appOptions,
            IOptions<JeebSetting> jeebOptions,
            ILogger<HomeController> logger)
        {
            _paymentClient = paymentClient;
            _appSetting = appOptions.Value;
            _jeebSetting = jeebOptions.Value;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IssueViewModel();
            ViewBag.BaseCurrencies = BaseCurrencies;
            ViewBag.Languages = Languages;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index([FromForm] IssueViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var model = new IssueViewModel();
                ViewBag.BaseCurrencies = BaseCurrencies;
                ViewBag.Languages = Languages;
                return View(model);
            }

            var dto = MapToIssueDto(viewModel);
            var payment = _paymentClient.Issue(dto);
            var url = _paymentClient.GetRedirectUrl(payment.Token);
            return Redirect(url);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        private IssueDto MapToIssueDto(IssueViewModel viewModel)
        {
            var orderNo = RandomTools.GetUniqueKey(10);
            var dto = new IssueDto
            {
                Type = viewModel.Type,
                Mode = viewModel.Mode,
                Client = viewModel.Client,

                OrderNo = orderNo,
                Language = viewModel.Language,
                PayableCoins = viewModel.PayableCoins,

                CallbackUrl = GetSecureCallbackUrl(orderNo),
                WebhookUrl = GetSecureWebhookUrl(orderNo),

                AllowReject = viewModel.AllowReject,
                AllowTestNets = viewModel.AllowTestNets
            };

            if (viewModel.Type == Constants.PaymentType.Restricted)
            {
                dto.BaseAmount = viewModel.BaseAmount;
                dto.BaseCurrencyId = viewModel.BaseCurrencyId;
            }

            if (dto.Language?.ToLower() == "auto")
            {
                dto.Language = null;
            }

            return dto;
        }

        private string GetSecureCallbackUrl(string orderNo)
        {
            var hash = SecurityTools.CalculatePaymentHash(_jeebSetting.ApiKey, orderNo);
            var builder = new UriBuilder(_appSetting.ServerRootAddress) {Path = "Callback", Query = $"hash={hash}"};
            return builder.ToString();
        }

        private string GetSecureWebhookUrl(string orderNo)
        {
            var hash = SecurityTools.CalculatePaymentHash(_jeebSetting.ApiKey, orderNo);
            var builder = new UriBuilder(_appSetting.ServerRootAddress) {Path = "Webhook", Query = $"hash={hash}"};
            return builder.ToString();
        }
        
        #region Statics

        private static readonly List<SelectListItem> BaseCurrencies = new List<SelectListItem>()
        {
            new SelectListItem("Bitcoin", "BTC"),
            new SelectListItem("Iranian Rials", "IRR"),
            new SelectListItem("Iranian Toman", "IRT"),
            new SelectListItem("US Dollar", "USD"),
            new SelectListItem("Pond", "GBP"),
            new SelectListItem("Euro", "EUR"),
            new SelectListItem("Australian Dollar", "AUD"),
            new SelectListItem("Canadian Dollar", "CAD")
        };

        private static readonly List<SelectListItem> Languages = new List<SelectListItem>()
        {
            new SelectListItem("Auto", null),
            new SelectListItem("Farsi", "fa"),
            new SelectListItem("English", "en")
        };

        #endregion
    }
}