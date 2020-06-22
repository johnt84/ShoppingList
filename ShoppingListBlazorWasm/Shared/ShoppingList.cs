using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingListBlazorWasm.Shared
{
    public class ShoppingList
    {
        public int ShoppingListID { get; set; }

        [Required]
        public DateTime ShoppingDate { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserID { get; set; }
        public int CopyShoppingListID { get; set; }
        public int NumberOfItems { get; set; }
    }
}
