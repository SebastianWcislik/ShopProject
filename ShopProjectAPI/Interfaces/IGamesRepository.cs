using ShopProjectExternalModel.Game;

namespace ShopProjectAPI.Interfaces
{
    public interface IGameRepository
    {
        GameDto GetGame(int id);
        GameDto[] GetGames();
    }
}