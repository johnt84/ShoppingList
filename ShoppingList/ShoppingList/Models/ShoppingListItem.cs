using System;

namespace ShoppingList.Models
{
    public class ShoppingListItem
    {
        public string Filename { get; set; }
        public string Text { get; set; }
        public bool InTrolley { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
