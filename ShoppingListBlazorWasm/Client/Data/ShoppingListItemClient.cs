using ShoppingListBlazorWasm.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShoppingListBlazorWasm.Client.Data
{
    public class ShoppingListItemClient
    {
        private readonly HttpClient _httpClient;
        private static string SHOPPING_LIST_ITEM_API_URL = "api/ShoppingListItem";

        public ShoppingListItemClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<ShoppingListItem>> GetShoppingListItems() =>
            await _httpClient.GetFromJsonAsync<List<ShoppingListItem>>(SHOPPING_LIST_ITEM_API_URL);


        public async Task<ShoppingListItem> GetShoppingListItem(Guid ID) =>
            await _httpClient.GetFromJsonAsync<ShoppingListItem>($"{SHOPPING_LIST_ITEM_API_URL }/{ID}");


        public async Task CreateShoppingListItem(ShoppingListItem shoppingListItem)
        {
            var response = await _httpClient.PostAsJsonAsync(SHOPPING_LIST_ITEM_API_URL, shoppingListItem);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateShoppingListItem(ShoppingListItem shoppingListItem)
        {
            var response = await _httpClient.PutAsJsonAsync(SHOPPING_LIST_ITEM_API_URL, shoppingListItem);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteShoppingListItem(Guid ID)
        {
            var response = await _httpClient.DeleteAsync($"{SHOPPING_LIST_ITEM_API_URL}/{ID}");
            response.EnsureSuccessStatusCode();
        }

    }
}
