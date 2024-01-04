using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.User;

namespace ShopProjectAPP.ViewModel
{
    public class UserRegisterViewModel :  ComponentBase
    {
        public HttpHelpers httpHelpers;

        public UserRegisterViewModel()
        {
            this.httpHelpers = new HttpHelpers();
        }

        public UserRegisterModel userRegister {  get; set; }

        public async Task<bool> UserRegistration()
        {
            string json = JsonConvert.SerializeObject(userRegister, Formatting.Indented);
            var jsonContent = new StringContent(json);
            var result = await httpHelpers.PostResponse<bool>(Program.url + "/User/Register", jsonContent);

            return result;
        }
    }
}
