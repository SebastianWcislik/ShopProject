using System;
using System.Collections.Generic;

namespace ShopProjectInfrastructure.DB;

public partial class OrderGame
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int GameId { get; set; }

    public string Key { get; set; } = null!;

    public virtual Game Game { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
