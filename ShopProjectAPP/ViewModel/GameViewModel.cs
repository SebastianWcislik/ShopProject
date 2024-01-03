using Microsoft.AspNetCore.Components;
using ShopProjectAPP.Components;
using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.Game;

namespace ShopProjectAPP.ViewModel
{
    public class GameViewModel : ComponentBase
    {
        [Parameter] public int CategoryId { get; set; } = 0;
        [Parameter] public DisplayGames? dg { get; set; } = null;

        public HttpHelpers httpHelper;

        public GameViewModel()
        {
            this.httpHelper = new HttpHelpers();
        }
        public GameModel[] Games { get; set; }
        public string GameCategory { get; set; }

        public async Task<GameModel[]> GetGames()
        {
            var result = await httpHelper.GetResponse<GameModel[]>(Program.url + "/Games/GetGames");
            return result;
        }

        public async Task<GameModel[]> GetGamesCategory()
        {
            var result = await httpHelper.GetResponse<GameModel[]>(Program.url + "/Games/GetGamesByCategory?CategoryId=" + CategoryId);
            return result;
        }

        protected override async void OnParametersSet()
        {
            if (dg == null)
            {
                if (CategoryId == 0)
                {
                    GameCategory = "Wszystkie gry";
                    Games = await GetGames();
                }
                else Games = await GetGamesCategory();
            }
            else
            {
                if (CategoryId == 0)
                {
                    dg.SetGames(await GetGames());
                    GameCategory = "Wszystkie gry";
                }
                else
                {
                    var result = await GetGamesCategory();
                    dg.SetGames(result);
                    GameCategory = result.Length == 0 ? "" : result[0].CategoryName;
                }
            }
            StateHasChanged();
        }
    }
}
