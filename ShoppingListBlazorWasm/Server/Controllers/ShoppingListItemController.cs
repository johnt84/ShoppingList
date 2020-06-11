using Microsoft.AspNetCore.Mvc;
using ShoppingListBlazorWasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListBlazorWasm.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListItemController : ControllerBase
    {
        private List<ShoppingListItem> shoppingListItems = new List<ShoppingListItem>()
        {
            new ShoppingListItem()
            {
                Name = "Bananas",
                Quantity = 1,
                ShoppingDate = shoppingDate,
            },
            new ShoppingListItem()
            {
                Name = "Tomatoes",
                Quantity = 1,
                ShoppingDate = shoppingDate,
            },
            new ShoppingListItem()
            {
                Name = "Lettuce",
                Quantity = 1,
                ShoppingDate = shoppingDate,
            },
        };
        private static DateTime shoppingDate = new DateTime(2020, 06, 11);


        [HttpGet]
        public List<ShoppingListItem> Get()
        {
            return shoppingListItems;
        }

        public ShoppingListItem Get(string shoppingItemName)
        {
            return shoppingListItems.First(x => x.Name == shoppingItemName);
        }

        [HttpPost]
        public IActionResult Create(ShoppingListItem shoppingListItem)
        {
            shoppingListItems.Add(shoppingListItem);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(ShoppingListItem shoppingListItem)
        {
            var shoppingListItemToUpdate = Get(shoppingListItem.Name);

            if (shoppingListItemToUpdate != null)
            {
                shoppingListItemToUpdate = shoppingListItem;
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(string shoppingItemName)
        {
            shoppingListItems.RemoveAll(x => x.Name == shoppingItemName);

            return Ok();
        }
    }
}
