using ShopProjectAPI.DB;
using ShopProjectAPI.Interfaces;
using ShopProjectAPI.Mappers;
using ShopProjectExternalModel.Game;

#nullable disable

namespace ShopProjectAPI.Repository
{
    public class GamesRepository : IGamesRepository
    {
        public ShopprojectContext db { get; set; }
        public GameMapper gm { get; set; }

        public GamesRepository(ShopprojectContext db, GameMapper gm)
        {
            this.db = db;
            this.gm = gm;
        }

        public GameModel[] GetGames()
        {
            var result = db.Games.Select(x => gm.MapToGameModel(x)).ToArray();

            return result;
        }

        public GameModel GetGame(int id)
        {
            var result = db.Games.Join(db.GameCategories, c => c.CategoryId, d => d.Id, (p, pc) => gm.MapToGameWithCategoryModel(p, pc)).AsEnumerable().FirstOrDefault(x => x.Id == id);

            if (result != null) return result;
            else return null;
        }

        public GameCategoryModel[] GetGameCategories()
        {
            var result = db.GameCategories.Select(x => gm.MapToGameCategoryModel(x)).ToArray();

            if (result != null) return result;
            else return null;
        }

        public GameModel[] GetGamesByCategory(int categoryId)
        {
            var result = db.Games.Where(x => x.CategoryId == categoryId).Join(db.GameCategories, c => c.CategoryId, d => d.Id, (p, pc) => gm.MapToGameWithCategoryModel(p, pc)).ToArray();

            if (result != null) return result;
            else return null;
        }

        public bool CheckGameById(int GameId)
        {
            if (db.Games.FirstOrDefault(x => x.Id == GameId) == null) return false;
            else return true;
        }
    }
}
