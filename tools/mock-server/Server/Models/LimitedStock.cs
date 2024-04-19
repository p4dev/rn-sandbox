using System;
namespace Server.Models
{
    public class LimitedStock
    {
        public long IngredientId { get; set; }
        public int QuantityRemaining { get; set; }
    }
}

