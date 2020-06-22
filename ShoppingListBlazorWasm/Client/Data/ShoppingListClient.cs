using ShoppingListBlazorWasm.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShoppingListBlazorWasm.Client.Data
{
    public class ShoppingListClient
    {
        private readonly HttpClient _httpClient;
        private static string SHOPPING_LIST_API_URL = "api/ShoppingList";
        private static string SHOPPING_LIST_ITEM_API_URL = "api/ShoppingListItem";

        public ShoppingListClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<ShoppingList>> GetShoppingLists() =>
            await _httpClient.GetFromJsonAsync<List<ShoppingList>>(SHOPPING_LIST_API_URL);


        public async Task<ShoppingList> GetShoppingList(int shoppingListID) =>
            await _httpClient.GetFromJsonAsync<ShoppingList>($"{SHOPPING_LIST_API_URL}/{shoppingListID}");


        public async Task CreateShoppingList(ShoppingList shoppingList)
        {
            var response = await _httpClient.PostAsJsonAsync(SHOPPING_LIST_API_URL, shoppingList);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateShoppingList(ShoppingList shoppingList)
        {
            var response = await _httpClient.PutAsJsonAsync(SHOPPING_LIST_API_URL, shoppingList);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteShoppingList(int shoppingListID)
        {
            var response = await _httpClient.DeleteAsync($"{SHOPPING_LIST_API_URL}/{shoppingListID}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ShoppingListItem>> GetShoppingListItems(int shoppingListID) =>
            await _httpClient.GetFromJsonAsync<List<ShoppingListItem>>($"{SHOPPING_LIST_ITEM_API_URL}/{shoppingListID}");


        public async Task<ShoppingListItem> GetShoppingListItem(int shoppingListItemID) =>
            await _httpClient.GetFromJsonAsync<ShoppingListItem>($"{SHOPPING_LIST_ITEM_API_URL}/0/{shoppingListItemID}");


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

        public async Task DeleteShoppingListItem(int shoppingListItemID)
        {
            var response = await _httpClient.DeleteAsync($"{SHOPPING_LIST_ITEM_API_URL}/{shoppingListItemID}");
            response.EnsureSuccessStatusCode();
        }

    }
}
