using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoppingListBlazorWasm.Shared;
using System.Collections.Generic;
using System.IO;

namespace ShoppingListBlazorWasm.Server.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ReadFromFile()
        {
            return File.ReadAllText(_configuration["ShoppingListItemsDataFile"]);
        }

        public void SaveToFile(List<ShoppingListItem> shoppingListItems)
        {
            string json = JsonConvert.SerializeObject(shoppingListItems);
            File.WriteAllText(_configuration["ShoppingListItemsDataFile"], json);
        }
    }
}
