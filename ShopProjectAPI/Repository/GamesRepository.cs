using ShopProjectAPI.DB;
using ShopProjectAPI.Interfaces;
using ShopProjectExternalModel.Game;

#nullable disable

namespace ShopProjectAPI.Repository
{
    public class GamesRepository : IGamesRepository
    {
        public ShopprojectContext db { get; set; }

        public GamesRepository(ShopprojectContext db)
        {
            this.db = db;
        }

        public GameDto[] GetGames()
        {
            var result = db.Games.Join(db.GameCategories, c => c.CategoryId, d => d.Id, (p, pc) => new GameDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageURL = p.ImageUrl,
                Price = p.Price,
                CategoryId = pc.Id,
                CategoryName = pc.Name
            }).ToArray();

            return result;
        }

        public GameDto GetGame(int id)
        {
            var result = db.Games.Join(db.GameCategories, c => c.CategoryId, d => d.Id, (p, pc) => new GameDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageURL = p.ImageUrl,
                Price = p.Price,
                CategoryId = pc.Id,
                CategoryName = pc.Name
            }).FirstOrDefault(x => x.Id == id);

            if (result != null) return result;
            else return null;
        }
    }
}
