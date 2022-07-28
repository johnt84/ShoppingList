-- =============================================
-- Author:		John Tomlinson
-- Create date: June 2020
-- Description:	Obtains the shopping lists for
-- the shoppping list ID provided
-- =============================================
CREATE PROCEDURE [dbo].[procShoppingListGet]
	@shoppingListID int = NULL
AS
BEGIN

	select 
		list.*
		,items.NumberOfItems
		,items.EstimatedTotalAmount
	from 
		shoppingList list
	left join
	(
		select 
			item.shoppingListID
			,sum(item.price * item.quantity) as EstimatedTotalAmount
			,count(*) as NumberOfItems
		from 
			shoppingListItem item
		where
			item.quantity > 0
		group by item.shoppingListID
	)items on list.shoppingListID = items.shoppingListID
	where 
		list.shoppingListID = iif(@shoppingListID is not null, @shoppingListID, list.shoppingListID)
	order by list.shoppingDate

END
