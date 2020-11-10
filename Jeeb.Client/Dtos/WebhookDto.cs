namespace Jeeb.Client.Dtos
{
    public class WebhookDto : PaymentDto
    {
        public int Attempts { set; get; }
    }
}