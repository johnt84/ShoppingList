-- =============================================
-- Author:		John Tomlinson
-- Create date: June 2020
-- Description:	Updates an existing shopping list item
-- =============================================
CREATE PROCEDURE [dbo].[procShoppingListItemUpdate]
	@shoppingListItemID int
	,@shoppingListID int
	,@itemName nvarchar(150)
	,@price decimal(18, 2)
	,@quantity int
	,@itemPicked int
AS
BEGIN

	declare @currentQuantity int
	declare @inStorePosition int

	select 
		@currentQuantity = item.quantity
		,@inStorePosition = item.inStorePosition
	from 
		shoppingListItem item
	where 
		item.shoppingListItemID = @shoppingListItemID

	/* 
		if changing quantity from greater than 0 to 0 then set the item's in store position to 0
		and move all the items below the item up a position to fill the item which has just been
		removed
	*/
	if @quantity = 0 and @currentQuantity > 0
	begin		
		-- move all shopping list items below the shopping list item which has had its quantity changed to 0
		-- in the same same shopping list up an in store position to fill 
		-- the "removed" shopping list item's in store position
		update 
			item
		set 
			item.inStorePosition = item.inStorePosition - 1
		from 
			shoppingListItem item
		where 
			item.shoppingListID = @shoppingListID
			and item.inStorePosition > @inStorePosition

		set @inStorePosition = 0
	end

	/*
		if the quantiy is changing from 0 to a non 0 quantity then move the item to the bottom
		of the list
	*/
	if @quantity > 0 and @currentQuantity = 0
	begin
		select	
			@inStorePosition = max(item.inStorePosition) + 1
		from 
			shoppingListItem item
		where
			item.shoppingListID = @shoppingListID
	end

	if @price = 0
	begin
		select 
			@price = latestItemPrice.price
		from 
			latestItemPrice 
		where 
			latestItemPrice.itemName = @itemName
	end
	
	update
		item
	set
		item.shoppingListID = @shoppingListID
		,item.itemName = @itemName
		,item.price = @price
		,item.quantity = @quantity
		,item.itemPicked = @itemPicked
		,item.inStorePosition = @inStorePosition
	from 
		shoppingListItem item
	where 
		item.shoppingListItemID = @shoppingListItemID

END