using System;
using System.Collections.Generic;

namespace ShopProjectInfrastructure.DB;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<OrderGame> OrderGames { get; set; } = new List<OrderGame>();

    public virtual User User { get; set; } = null!;
}
