using Jeeb.Client.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Jeeb.Client.Dtos
{
    public class CurrencyDto
    {
        public string Id { set; get; }

        public string Parent { set; get; }

        public int Index { set; get; }

        public string Name { set; get; }


        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.CurrencyType Type { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.CurrencyNetwork? Network { set; get; }


        public int Precision { set; get; }


        public bool IsActive { get; set; }


        public bool AllowDeposit { set; get; }

        public bool AllowWithdraw { set; get; }

        public bool AllowPayment { set; get; }



        public decimal? MinDepositLimit { set; get; }

        public decimal? MaxDepositLimit { set; get; }

        public decimal? MinWithdrawLimit { set; get; }

        public decimal? MaxWithdrawLimit { set; get; }

        public decimal? MinPaymentLimit { set; get; }

        public decimal? MaxPaymentLimit { set; get; }

        public override string ToString()
        {
            return $"[{Id}({Name})]";
        }
    }
}