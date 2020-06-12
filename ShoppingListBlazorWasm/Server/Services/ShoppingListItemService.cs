using Newtonsoft.Json;
using ShoppingListBlazorWasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingListBlazorWasm.Server.Services
{
    public class ShoppingListItemService : IShoppingListItemService
    {
        private readonly IFileService _fileService;
        private List<ShoppingListItem> shoppingListItems;

        public ShoppingListItemService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public List<ShoppingListItem> Get()
        {
            string json = _fileService.ReadFromFile();
            return JsonConvert.DeserializeObject<List<ShoppingListItem>>(json);
        }

        public ShoppingListItem Get(Guid ID)
        {
            shoppingListItems = Get();
            return shoppingListItems.First(x => x.ID == ID);
        }

        public void Add(ShoppingListItem shoppingListItem)
        {
            shoppingListItems = Get();

            shoppingListItem.ID = Guid.NewGuid();
            shoppingListItems.Add(shoppingListItem);

            _fileService.SaveToFile(shoppingListItems);
        }

        public void Update(ShoppingListItem shoppingListItem)
        {
            shoppingListItems = Get();

            int updatedShoppingItemIndex = shoppingListItems.FindIndex(x => x.ID == shoppingListItem.ID);
            shoppingListItems.RemoveAll(x => x.ID == shoppingListItem.ID);
            shoppingListItems.Insert(updatedShoppingItemIndex, shoppingListItem);

            _fileService.SaveToFile(shoppingListItems);
        }

        public void Delete(Guid ID)
        {
            shoppingListItems = Get();
            shoppingListItems.RemoveAll(x => x.ID == ID);
            _fileService.SaveToFile(shoppingListItems);
        }
    }
}
