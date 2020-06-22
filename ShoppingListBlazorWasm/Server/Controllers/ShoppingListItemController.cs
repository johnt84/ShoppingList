using Microsoft.AspNetCore.Mvc;
using ShoppingListBlazorWasm.Server.Services;
using ShoppingListBlazorWasm.Shared;
using System;
using System.Collections.Generic;

namespace ShoppingListBlazorWasm.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingListItemController : ControllerBase
    {
        private readonly IShoppingListItemService _shoppingListItemService;

        public ShoppingListItemController(IShoppingListItemService shoppingListItemService)
        {
            _shoppingListItemService = shoppingListItemService;
        }

        [HttpGet("{shoppingListID}")]
        public List<ShoppingListItem> Get(int shoppingListID)
        {
            return _shoppingListItemService.Get(shoppingListID);
        }

        [HttpGet("{shoppingListID}/{shoppingListItemID}")]
        public ShoppingListItem GetItem(int shoppingListItemID)
        {
            return _shoppingListItemService.GetItem(shoppingListItemID);
        }

        [HttpPost]
        public IActionResult Create(ShoppingListItem shoppingListItem)
        {
            _shoppingListItemService.Add(shoppingListItem);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(ShoppingListItem shoppingListItem)
        {
            _shoppingListItemService.Update(shoppingListItem);

            return Ok();
        }

        [HttpDelete("{shoppingListItemID}")]
        public IActionResult Delete(int shoppingListItemID)
        {
            _shoppingListItemService.Delete(shoppingListItemID);

            return Ok();
        }
    }
}
