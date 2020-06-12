using Microsoft.AspNetCore.Mvc;
using ShoppingListBlazorWasm.Server.Services;
using ShoppingListBlazorWasm.Shared;
using System.Collections.Generic;
using System;

namespace ShoppingListBlazorWasm.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListItemController : ControllerBase
    {
        private readonly IShoppingListItemService _shoppingListItemService;

        public ShoppingListItemController(IShoppingListItemService shoppingListItemService)
        {
            _shoppingListItemService = shoppingListItemService;
        }

        [HttpGet]
        public List<ShoppingListItem> Get()
        {
            return _shoppingListItemService.Get();
        }

        [HttpGet("{shoppingListItemID}")]
        public ShoppingListItem Get(Guid shoppingListItemID)
        {
            return _shoppingListItemService.Get(shoppingListItemID);
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

        [HttpDelete]
        public IActionResult Delete(Guid ID)
        {
            _shoppingListItemService.Delete(ID);

            return Ok();
        }
    }
}
