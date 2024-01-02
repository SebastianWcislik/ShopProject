using Microsoft.AspNetCore.Components;
using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.Game;

namespace ShopProjectAPP.ViewModel
{
    public class GameViewModel : ComponentBase
    {
        public HttpHelpers httpHelper;

        public GameViewModel()
        {
            this.httpHelper = new HttpHelpers();
        }

        public GameDto[] Games { get; set; }

        public async Task<GameDto[]> GetGames()
        {
            var result = await httpHelper.GetResponse<GameDto[]>(Program.url + "/Games/GetGames");
            return result;
        }

        protected override async void OnInitialized()
        {
            var result = await GetGames();
            Games = result;
            StateHasChanged();
        }
    }
}
