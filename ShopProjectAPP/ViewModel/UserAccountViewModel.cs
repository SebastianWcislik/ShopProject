using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ShopProjectAPP.Helpers;
using ShopProjectAPP.Modals;
using ShopProjectExternalModel.Responses;
using ShopProjectExternalModel.User;

namespace ShopProjectAPP.ViewModel
{
    public class UserAccountViewModel : ComponentBase
    {
        public HttpHelpers httpHelpers;

        public EditContext editContext { get; set; }
        public ValidationMessageStore editContextErrors { get; set; }
        [Inject]
        public ILocalStorageService local { get; set; }
        [Inject]
        public IToastService toastService { get; set; }
        [Inject]
        public IModalService Modal { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public UserAccountViewModel()
        {
            this.httpHelpers = new HttpHelpers();
        }

        public UserLoginDataMessage userAccount { get; set; }
        public UserUpdateModel userUpdate { get; set; }

        protected override async void OnInitialized()
        {
            var userId = await local.GetItemAsync<int>("UserId");
            var result = await httpHelpers.GetResponse<UserLoginDataMessage>(Program.userUrl + "/User/GetUserById?UserId=" + userId);
            userAccount = result;
            userUpdate = new UserUpdateModel { UserId = userId };
            editContext = new EditContext(userUpdate);
            editContext.OnFieldChanged += EditContext_OnFieldChanged;
            editContextErrors = new ValidationMessageStore(editContext);
            StateHasChanged();
        }

        private void EditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            editContextErrors.Clear(e.FieldIdentifier);
            editContext.NotifyValidationStateChanged();
            StateHasChanged();
        }

        public async void UserUpdate()
        {
            if (editContext.Validate())
            {
                var result = await httpHelpers.PutResponse<bool>(Program.userActionUrl + "/User/ChangePassword", editContext.Model);
                if (result)
                {
                    toastService.ShowSuccess("Zmiana hasła została przeprowadzona pomyślnie.");
                    userUpdate = new UserUpdateModel();
                    StateHasChanged();
                }
                else
                {
                    toastService.ShowError("Nie udało się aktualizować hasła użytkownika. Spróbuj ponownie.");
                }
            }
        }

        public async void DeleteUser()
        {
            var parameters = new ModalParameters().Add(nameof(ConfirmationDialog.Message), "Czy chcesz usunąć konto?").Add(nameof(ConfirmationDialog.Title), "Potwierdź operację");
            var modalResult = Modal.Show<ConfirmationDialog>("Potwierdzenie usunięcia", parameters);
            var result = await modalResult.Result;

            if (result.Confirmed)
            {
                var userId = await local.GetItemAsync<int>("UserId");
                var deleteReturn = await httpHelpers.DeleteResponse<bool>(Program.userActionUrl + "/User/DeleteUser?UserId=" + userId);
                if (deleteReturn)
                {
                    await local.RemoveItemAsync("Cart" + userId);
                    await local.RemoveItemAsync("Username");
                    await local.RemoveItemAsync("UserId");
                    toastService.ShowSuccess("Udało się usunąć konto.");
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    toastService.ShowError("Nie udało się usunąć konta. Spróbuj ponownie.");
                }
            }
            else return;
        }
    }
}
