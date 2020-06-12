using ShoppingListBlazorWasm.Shared;
using System.Collections.Generic;

namespace ShoppingListBlazorWasm.Server.Services
{
    public interface IFileService
    {
        public string ReadFromFile();
        public void SaveToFile(List<ShoppingListItem> shoppingListItems);
    }
}
