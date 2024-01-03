using ShopProjectAPI.DB;
using ShopProjectExternalModel.Game;

namespace ShopProjectAPI.Mappers
{
    public class GameMapper
    {
        public GameModel MapToGameWithCategoryModel(Game x, GameCategory y)
        {
            return new GameModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageURL = x.ImageUrl,
                Price = x.Price,
                CategoryId = y.Id,
                CategoryName = y.Name
            };
        }

        public GameModel MapToGameModel(Game x)
        {
            return new GameModel {
                Id = x.Id, 
                Name = x.Name, 
                CategoryId = x.CategoryId,
                Description = x.Description, 
                ImageURL = x.ImageUrl, 
                Price = x.Price 
            };
        }

        public GameCategoryModel MapToGameCategoryModel(GameCategory x)
        {
            return new GameCategoryModel
            {
                Id = x.Id,
                Name = x.Name
            };
        }
    }
}
