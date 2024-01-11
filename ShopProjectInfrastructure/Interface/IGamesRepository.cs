using ShopProjectExternalModel.Game;

namespace ShopProjectInfrastructure.Interfaces
{
    public interface IGamesRepository
    {
        GameModel GetGame(int id);
        GameModel[] GetGames();
        GameCategoryModel[] GetGameCategories();
        GameModel[] GetGamesByCategory(int categoryId);
        bool CheckGameById(int GameId);
    }
}