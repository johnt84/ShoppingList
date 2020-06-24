using Microsoft.AspNetCore.Mvc;
using ShoppingListBlazorWasm.Server.Services;
using ShoppingListBlazorWasm.Shared;
using System.Collections.Generic;

namespace ShoppingListBlazorWasm.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [HttpGet()]
        public List<ShoppingList> Get()
        {
            return _shoppingListService.Get();
        }

        [HttpGet("{shoppingListID}")]
        public ShoppingList Get(int shoppingListID)
        {
            return _shoppingListService.Get(shoppingListID);
        }

        [HttpPost]
        public ActionResult<int> Create(ShoppingList shoppingList)
        {
            return _shoppingListService.Add(shoppingList);
        }

        [HttpPut]
        public IActionResult Update(ShoppingList shoppingList)
        {
            _shoppingListService.Update(shoppingList);

            return Ok();
        }

        [HttpDelete("{shoppingListID}")]
        public IActionResult Delete(int shoppingListID)
        {
            _shoppingListService.Delete(shoppingListID);

            return Ok();
        }
    }
}
