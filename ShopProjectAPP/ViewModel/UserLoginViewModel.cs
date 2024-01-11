using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.Cart;
using ShopProjectExternalModel.Responses;
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
        [Inject]
        public IToastService toast { get; set; }
        [Inject]
        public IJSRuntime runtime { get; set; }

        public async void UserLogin()
        {
            if (editContext.Validate())
            {
                var result = await httpHelpers.PostResponse<UserLoginMessage>(Program.userUrl + "/User/Login", editContext.Model);
                if (result != null)
                {
                    await local.SetItemAsync("Username", result.Username);
                    await local.SetItemAsync("UserId", result.UserId);
                    var myCart = await local.ContainKeyAsync("Cart" + result.UserId);
                    if (myCart == false) await local.SetItemAsync("Cart" + result.UserId, new List<CartModel> { });
                    toast.ShowSuccess("Udało się zalogować");
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    toast.ShowError("Podano niepoprawne dane.");
                }
            }
        }

        protected override void OnInitialized()
        {
            userLogin = new UserLoginModel();
            editContext = new EditContext(userLogin);
        }

        public void NavigateToMainMenu()
        {
            runtime.InvokeVoidAsync("history.back");
        }

        public void Register()
        {
            NavigationManager.NavigateTo("/register");
        }
    }
}
