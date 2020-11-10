namespace Jeeb.Client.Demo.Utils
{
    public static class SecurityTools
    {
        public static string CalculatePaymentHash(string apiKey, string orderNo)
        {
            return HashTools.Sha256Hash($"{apiKey}:{orderNo}");
        }

        public static bool VerifyPaymentHash(string apiKey, string orderNo, string hash)
        {
            return string.Equals(CalculatePaymentHash(apiKey, orderNo), hash);
        }
    }
}