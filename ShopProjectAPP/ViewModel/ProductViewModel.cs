using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.User;

namespace ShopProjectAPP.ViewModel
{
    public class ProductViewModel : HttpHelpers
    {
        public string url { get; set; }

        public ProductViewModel(IConfiguration config)
        {
            this.url = config.GetValue<string>("HttpAddress");
        }

        public UserLoginModel[] users { get; set; }

        public async Task Test()
        {
            var result = await GetResponse<UserLoginModel[]>(url + "/Car/Test");
            users = result;
        }
    }
}
