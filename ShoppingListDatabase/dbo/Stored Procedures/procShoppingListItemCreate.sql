-- =============================================
-- Author:		John Tomlinson
-- Create date: June 2020
-- Description:	Creates a new shopping list item
-- =============================================
CREATE PROCEDURE [dbo].[procShoppingListItemCreate]
	@shoppingListID int
	,@itemName nvarchar(150)
	,@price decimal(18, 2)
	,@quantity int
	,@itemPicked int
AS
BEGIN

	declare @newInStorePosition int = 1

	select 
		@newInStorePosition = iif(@quantity > 0, max(item.inStorePosition) + 1, 0)
	from 
		shoppingListItem item
	where 
		item.shoppingListID = @shoppingListID

	set @newInStorePosition = iif(@newInStorePosition is null, 1, @newInStorePosition)

	if @price = 0
	begin
		select 
			@price = latestItemPrice.price
		from 
			latestItemPrice 
		where 
			latestItemPrice.itemName = @itemName
	end
	
	insert into shoppingListItem
	(
		shoppingListID
		, itemName
		, price
		, quantity
		, itemPicked
		, inStorePosition
	)
	values
	(
		@shoppingListID
		,@itemName
		,@price
		,@quantity
		,@itemPicked
		,@newInStorePosition
	)

	declare @newShoppingListItemID int

	select @newShoppingListItemID = SCOPE_IDENTITY()
	
	select @newShoppingListItemID

END