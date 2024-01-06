using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.User;

namespace ShopProjectAPP.ViewModel
{
    public class UserLoginViewModel : ComponentBase
    {
        public HttpHelpers httpHelpers;
        public UserLoginViewModel()
        {
            this.httpHelpers = new HttpHelpers();
        }

        public UserLoginModel userLogin { get; set; }
        public EditContext editContext { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ILocalStorageService local { get; set; }

        public async void UserLogin()
        {
            if (editContext.Validate())
            {
                var result = await httpHelpers.PostResponse<bool>(Program.url + "/User/Register", editContext.Model);
                Console.WriteLine(result);
            }
        }

        protected override void OnInitialized()
        {
            userLogin = new UserLoginModel();
            editContext = new EditContext(userLogin);
        }

        public void NavigateToMainMenu()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
