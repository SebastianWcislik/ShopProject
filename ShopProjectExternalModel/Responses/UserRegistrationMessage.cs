namespace ShopProjectExternalModel.Responses
{
    public class UserRegistrationMessage
    {
        public bool isSuccess { get; set; }
        public Dictionary<string, string>? Errors { get; set; }
    }
}
