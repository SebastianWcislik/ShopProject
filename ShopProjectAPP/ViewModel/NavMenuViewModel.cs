using Microsoft.AspNetCore.Components;
using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.Game;

namespace ShopProjectAPP.ViewModel
{
    public class NavMenuViewModel : ComponentBase
    {
        public HttpHelpers httpHelper;

        public NavMenuViewModel()
        {
            this.httpHelper = new HttpHelpers();
        }

        public GameCategoryModel[] GamesCategories { get; set; }

        public async Task<GameCategoryModel[]> GetGameCategories()
        {
            var result = await httpHelper.GetResponse<GameCategoryModel[]>(Program.gamesUrl + "/Games/GetGameCategories");
            return result;
        }

        protected override async void OnInitialized()
        {
            GamesCategories = await GetGameCategories();
            StateHasChanged();
        }
    }
}
