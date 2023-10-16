namespace ShopProjectAPP.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void test()
        {
            RequestId = Guid.NewGuid().ToString();
        }
    }
}