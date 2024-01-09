using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using ShopProjectAPP.Pages;
using ShopProjectExternalModel.Cart;
using System.Threading.Tasks;

namespace ShopProjectAPP.ViewModel
{
    public class CartViewModel : ComponentBase
    {
        public string LoadingText { get; set; } = "Trwa wczytywanie koszyka...";
        public List<CartModel> Cart { get; set; }
        public decimal? TotalPrice { get; set; } = 0;
        [Inject]
        public ILocalStorageService local { get; set; }
        [Inject]
        public IToastService toast { get; set; }

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
            GetTotalPrice();
            StateHasChanged();
        }

        protected async Task Delete(int GameId)
        {
            var userId = await local.GetItemAsync<int>("UserId");
            var myCart = await local.GetItemAsync<List<CartModel>>("Cart" + userId);

            myCart.RemoveAll(x => x.GameId == GameId);

            await local.RemoveItemAsync("Cart" + userId);
            await local.SetItemAsync("Cart" + userId, myCart);
            toast.ShowSuccess("Usunięto koszyka");

            Cart = myCart;
            GetTotalPrice();
            StateHasChanged();
        }

        public async void GetTotalPrice()
        {
            TotalPrice = 0;
            var userId = await local.GetItemAsync<int>("UserId");
            var myCart = await local.GetItemAsync<List<CartModel>>("Cart" + userId);
            foreach (var cartItem in myCart)
            {
                TotalPrice += cartItem.Price * cartItem.Quantity;
            }
            StateHasChanged();
        }

        protected async Task UpdateQuantity()
        {
            var userId = await local.GetItemAsync<int>("UserId");

            await local.RemoveItemAsync("Cart" + userId);
            await local.SetItemAsync("Cart" + userId, Cart);

            GetTotalPrice();
        }
    }
}