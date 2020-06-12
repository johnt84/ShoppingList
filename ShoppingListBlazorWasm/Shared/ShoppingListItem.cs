using System;

namespace ShoppingListBlazorWasm.Shared
{
    public class ShoppingListItem
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool ItemPicked { get; set; }
    }
}
