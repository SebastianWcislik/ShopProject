using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.Game;

namespace ShopProjectAPP.ViewModel
{
    public class GameDetailViewModel : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        public GameModel Game { get; set; }
        public HttpHelpers httpHelper { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

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
            var result = await GetGame();
            if (result != null)
            {
                Game = result;
                StateHasChanged();
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }

        public void NavigateToMainMenu()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
