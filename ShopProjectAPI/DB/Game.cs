using System;
using System.Collections.Generic;

namespace ShopProjectAPI.DB;

public partial class Game
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public virtual GameCategory Category { get; set; } = null!;

    public virtual ICollection<OrderGame> OrderGames { get; set; } = new List<OrderGame>();
}
