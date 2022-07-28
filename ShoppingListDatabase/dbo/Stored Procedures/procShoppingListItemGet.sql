-- =============================================
-- Author:		John Tomlinson
-- Create date: June 2020
-- Description:	Obtains the shopping list items for
-- the shoppping list ID or shopping list item ID 
-- provided
-- =============================================
CREATE PROCEDURE [dbo].[procShoppingListItemGet]
	@shoppingListID int = NULL
	,@shoppingListItemID int = NULL
AS
BEGIN

	select 
		list.shoppingListID
		,list.shoppingDate
		,list.dateCreated
		,list.totalAmount
		,item.shoppingListItemID
		,item.itemName
		,item.price
		,item.quantity
		,item.price * item.quantity as itemCost
		,item.itemPicked
		,item.inStorePosition
	from 
		shoppingListItem item
	inner join shoppingList list on item.shoppingListID = list.shoppingListID
	where 
		item.shoppingListID = iif(@shoppingListID is not null, @shoppingListID, item.shoppingListID)
		and item.shoppingListItemID = iif(@shoppingListItemID is not null, @shoppingListItemID, item.shoppingListItemID)
	order by list.shoppingDate, item.shoppingListItemID

END
