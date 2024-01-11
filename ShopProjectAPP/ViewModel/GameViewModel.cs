using Microsoft.AspNetCore.Components;
using ShopProjectAPP.Components;
using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.Game;

namespace ShopProjectAPP.ViewModel
{
    public class GameViewModel : ComponentBase
    {
        [Parameter] public int? CategoryId { get; set; }
        [Parameter] public DisplayGames? dg { get; set; } = null;

        public HttpHelpers httpHelper;

        public GameViewModel()
        {
            this.httpHelper = new HttpHelpers();
        }
        public GameModel[] Games { get; set; }
        public string GameCategory { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task<GameModel[]> GetGames()
        {
            var result = await httpHelper.GetResponse<GameModel[]>(Program.gamesUrl + "/Games/GetGames");
            return result;
        }

        public async Task<GameModel[]> GetGamesCategory()
        {
            var result = await httpHelper.GetResponse<GameModel[]>(Program.gamesUrl + "/Games/GetGamesByCategory?CategoryId=" + CategoryId);
            return result;
        }

        protected override async void OnParametersSet()
        {
            var uriSplit = NavigationManager.Uri.Split("/");
            if (uriSplit.Length == 5) CategoryId = Convert.ToInt32(uriSplit[4]);
            else CategoryId = null;

            if (CategoryId == null)
            {
                if (dg == null) Games = await GetGames();
                else dg.SetGames(await GetGames());
                GameCategory = "Wszystkie gry";
            }
            else
            {
                var result = await GetGamesCategory();
                if (dg == null) Games = result;
                else dg.SetGames(result);
                GameCategory = result.Length == 0 ? "" : result[0].CategoryName;
            }
            StateHasChanged();
        }
    }
}
