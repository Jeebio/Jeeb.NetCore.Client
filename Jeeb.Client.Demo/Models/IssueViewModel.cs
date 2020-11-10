using System.ComponentModel.DataAnnotations;
using Jeeb.Client.Common;

namespace Jeeb.Client.Demo.Models
{
    public class IssueViewModel
    {
        public Constants.PaymentType Type { set; get; } = Constants.PaymentType.Restricted;

        public Constants.PaymentMode Mode { set; get; } = Constants.PaymentMode.Standard;

        public Constants.PaymentClient Client { set; get; } = Constants.PaymentClient.Internal;

        public string PayableCoins { set; get; } = "BTC/ETH/USDT/USDC/LTC/DOGE/TBTC/TETH";

        [Required] public string BaseCurrencyId { set; get; } = "IRT";

        [Required] public decimal BaseAmount { set; get; } = 10_000M;

        public string Language { set; get; } = null;

        [Required] public bool AllowReject { set; get; } = true;

        [Required] public bool AllowTestNets { set; get; } = true;
    }
}