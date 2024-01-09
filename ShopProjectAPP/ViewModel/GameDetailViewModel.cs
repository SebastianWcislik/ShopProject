using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.Cart;
using ShopProjectExternalModel.Game;

namespace ShopProjectAPP.ViewModel
{
    public class GameDetailViewModel : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        public GameModel Game { get; set; }
        public HttpHelpers httpHelper { get; set; }
        public int UserId { get; set; } = 0;
        public bool ShowSameGame { get; set; } = true;
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ILocalStorageService local {  get; set; }
        [Inject]
        public IToastService toast {  get; set; }

        public GameDetailViewModel()
        {
            this.httpHelper = new HttpHelpers();
        }

        public async Task<GameModel> GetGame()
        {
            var result = await httpHelper.GetResponse<GameModel>(Program.url + "/Games/GetGame?Id=" + Id);
            return result;
        }

        protected override async void OnInitialized()
        {
            var userId = await local.GetItemAsync<int?>("UserId");
            if (userId != null) UserId = (int)userId;

            var result = await GetGame();
            if (result != null)
            {
                Game = result;

                var myCart = await local.GetItemAsync<List<CartModel>>("Cart" + userId);
                if (myCart != null)
                {
                    ShowSameGame = myCart.Any(x => x.GameId == Game.Id);
                }
               
                StateHasChanged();
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }

        public async void AddToCart()
        {
            var userId = await local.GetItemAsync<int>("UserId");
            var myCart = await local.GetItemAsync<List<CartModel>>("Cart" + userId);
            myCart.Add(new CartModel { GameId = Game.Id, Name = Game.Name, Description=Game.Description, Price = Game.Price, ImageURL = Game.ImageURL, Quantity = 1 });
            await local.RemoveItemAsync("Cart" + userId); 
            await local.SetItemAsync("Cart" + userId, myCart);
            toast.ShowSuccess("Dodano do koszyka");
            ShowSameGame = true;
            StateHasChanged();
        }

        public void NavigateToMainMenu()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
