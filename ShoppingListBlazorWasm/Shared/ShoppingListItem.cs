using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingListBlazorWasm.Shared
{
    public class ShoppingListItem
    {
        public int ShoppingListItemID { get; set; }

        [Required]
        public int ShoppingListID { get; set; }

        [Required]
        public string ItemName { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool ItemPicked { get; set; }
        public decimal ItemCost { get; set; }

        public DateTime ShoppingDate { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
