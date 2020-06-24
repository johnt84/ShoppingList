using ShoppingListBlazorWasm.Shared;
using System.Collections.Generic;

namespace ShoppingListBlazorWasm.Server.Services
{
    public interface IShoppingListService
    {
        public List<ShoppingList> Get();
        public ShoppingList Get(int shoppingListID);
        public int Add(ShoppingList shoppingListItem);
        public void Update(ShoppingList shoppingListItem);
        public void Delete(int shoppingListID);
    }
}
