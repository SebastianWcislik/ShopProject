using ShopProjectExternalModel.Game;

namespace ShopProjectAPI.Interfaces
{
    public interface IGamesRepository
    {
        GameDto GetGame(int id);
        GameDto[] GetGames();
    }
}