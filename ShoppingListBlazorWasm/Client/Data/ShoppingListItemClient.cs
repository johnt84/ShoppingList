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

        public ShoppingListItemClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<ShoppingListItem>> GetShoppingListItems() =>
            await _httpClient.GetFromJsonAsync<List<ShoppingListItem>>("ShoppingListItem");


        public async Task<ShoppingListItem> GetShoppingListItem(Guid ID) =>
            await _httpClient.GetFromJsonAsync<ShoppingListItem>($"ShoppingListItem/{ID}");


        public async Task CreateShoppingListItem(ShoppingListItem shoppingListItem)
        {
            var response = await _httpClient.PostAsJsonAsync("ShoppingListItem", shoppingListItem);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateShoppingListItem(ShoppingListItem shoppingListItem)
        {
            var response = await _httpClient.PutAsJsonAsync("ShoppingListItem", shoppingListItem);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteShoppingListItem(Guid ID)
        {
            var response = await _httpClient.DeleteAsync($"ShoppingListItem{ID}");
            response.EnsureSuccessStatusCode();
        }

    }
}
