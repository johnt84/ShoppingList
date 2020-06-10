using Microsoft.AspNetCore.Mvc;
using ShoppingListBlazorWasm.Shared;
using System;
using System.Collections.Generic;

namespace ShoppingListBlazorWasm.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListItemController : ControllerBase
    {
        private List<ShoppingListItem> shoppingListItems;
        private static DateTime shoppingDate = new DateTime(2020, 06, 11);

        [HttpGet]
        public List<ShoppingListItem> Get()
        {
            shoppingListItems = new List<ShoppingListItem>()
            {
                new ShoppingListItem()
                {
                    Name = "Bananas",
                    Price = 0,
                    Quantity = 1,
                    ShoppingDate = shoppingDate,
                    ItemPicked = false,
                },
                new ShoppingListItem()
                {
                    Name = "Tomatoes",
                    Price = 0,
                    Quantity = 1,
                    ShoppingDate = shoppingDate,
                    ItemPicked = false,
                },
                new ShoppingListItem()
                {
                    Name = "Lettuce",
                    Price = 0,
                    Quantity = 1,
                    ShoppingDate = shoppingDate,
                    ItemPicked = false
                }
            };

            return shoppingListItems;
        }
    }
}
