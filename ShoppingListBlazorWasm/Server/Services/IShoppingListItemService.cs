using ShoppingListBlazorWasm.Shared;
using System.Collections.Generic;

namespace ShoppingListBlazorWasm.Server.Services
{
    public interface IShoppingListItemService
    {
        public List<ShoppingListItem> Get(int shoppingListID);
        public ShoppingListItem GetItem(int shoppingListItemID);
        public int Add(ShoppingListItem shoppingListItem);
        public void Update(ShoppingListItem shoppingListItem);
        public void Delete(int shoppingListItemID);
    }
}
