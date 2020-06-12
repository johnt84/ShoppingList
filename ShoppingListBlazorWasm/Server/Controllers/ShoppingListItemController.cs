using Microsoft.AspNetCore.Mvc;
using ShoppingListBlazorWasm.Server.Services;
using ShoppingListBlazorWasm.Shared;
using System.Collections.Generic;
using System;

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

        [HttpGet]
        public List<ShoppingListItem> Get()
        {
            return _shoppingListItemService.Get();
        }

        [HttpGet("{ID}")]
        public ShoppingListItem Get(Guid ID)
        {
            return _shoppingListItemService.Get(ID);
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

        [HttpDelete("{ID}")]
        public IActionResult Delete(Guid ID)
        {
            _shoppingListItemService.Delete(ID);

            return Ok();
        }
    }
}
