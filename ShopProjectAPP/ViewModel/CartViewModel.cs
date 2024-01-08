using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using ShopProjectExternalModel.Cart;

namespace ShopProjectAPP.ViewModel
{
    public class CartViewModel : ComponentBase
    {
        public string LoadingText { get; set; } = "Trwa wczytywanie koszyka...";
        public List<CartModel> Cart { get; set; }
        [Inject]
        public ILocalStorageService local {  get; set; }

        protected override async void OnInitialized()
        {
            var userId = await local.GetItemAsync<int>("UserId");
            var myCart = await local.GetItemAsync<List<CartModel>>("Cart" + userId);
            if (myCart == null || myCart.Count == 0)
            {
                LoadingText = "Koszyk jest pusty";
                StateHasChanged();
                return;
            }
            Cart = myCart;
            StateHasChanged();
        }
    }
}
