namespace Streamline.Ussd.Models
{
    public class UssdRequest
    {
        public string sessionId { get; set; }
        public string serviceCode { get; set; }
        public string phoneNumber { get; set; }
        public string text { get; set; }
    }
}
