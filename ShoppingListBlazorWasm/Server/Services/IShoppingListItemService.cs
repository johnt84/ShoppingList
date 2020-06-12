using ShoppingListBlazorWasm.Shared;
using System;
using System.Collections.Generic;

namespace ShoppingListBlazorWasm.Server.Services
{
    public interface IShoppingListItemService
    {
        public List<ShoppingListItem> Get();
        public ShoppingListItem Get(Guid ID);
        public void Add(ShoppingListItem shoppingListItem);
        public void Update(ShoppingListItem shoppingListItem);
        public void Delete(Guid ID);
    }
}
