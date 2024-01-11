using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.Responses;
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
        public EditContext editContext { get; set; }
        public ValidationMessageStore editContextErrors { get; set; }
        [Inject]
        public IToastService toastService { get; set; }
        [Inject]
        public IJSRuntime runtime { get; set; }

        public async void UserRegistration()
        {
            if (editContext.Validate())
            {
                var result = await httpHelpers.PostResponse<UserRegistrationMessage>(Program.userActionUrl + "/User/Register", editContext.Model);

                if (result.Errors != null)
                {
                    editContextErrors.Clear();
                    foreach (var error in result.Errors)
                    {
                        var field = editContext.Field(error.Key);
                        editContextErrors.Add(field, error.Value);
                    }
                    editContext.NotifyValidationStateChanged();
                    StateHasChanged();
                }
                else
                {
                    toastService.ShowSuccess("Rejestracja użytkownika została przeprowadzona pomyślnie.");
                    userRegister = new UserRegisterModel();
                    StateHasChanged();
                }
            }
        }

        protected override void OnInitialized()
        {
            userRegister = new UserRegisterModel();
            editContext = new EditContext(userRegister);
            editContext.OnFieldChanged += EditContext_OnFieldChanged;
            editContextErrors = new ValidationMessageStore(editContext);
        }

        private void EditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            editContextErrors.Clear(e.FieldIdentifier);
            editContext.NotifyValidationStateChanged();
            StateHasChanged();
        }

        public void NavigateToMainMenu()
        {
            runtime.InvokeVoidAsync("history.back");
        }
    }
}
