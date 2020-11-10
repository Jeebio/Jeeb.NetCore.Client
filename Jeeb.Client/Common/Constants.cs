namespace Jeeb.Client.Common
{
    public static class Constants
    {
        public enum CurrencyType
        {
            Crypto,
            Fiat,
        }

        public enum CurrencyNetwork
        {
            Mainnet,
            Testnet
        }
        
        public enum PaymentType
        {
            Arbitrary,
            Restricted
        }
        
        public enum PaymentMode
        {
            Standard,
            Fast
        }
        
        public enum PaymentClient
        {
            Internal,
            External
        }
        
        public enum PaymentState
        {
            Created,
            PendingTransaction,
            PendingConfirmation,
            Completed,
            Expired,
            Rejected,
            Failed
        }
        
        public enum PaymentDetailState
        {
            Quoted,
            Deployed,
            Used
        }


        public static PaymentType DefaultPaymentType => PaymentType.Restricted;

        public static PaymentMode DefaultPaymentMode => PaymentMode.Standard;

        public static PaymentClient DefaultPaymentClient => PaymentClient.Internal;
        
        
        public const int DefaultExpiration = 20;
        

        public const bool DefaultAllowReject = true;

        public const bool DefaultAllowTestNets = false;


    }
}