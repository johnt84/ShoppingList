-- =============================================
-- Author:		John Tomlinson
-- Create date: July 2020
-- Description:	Moves the shopping list item matching the 
-- shopping list item id passed into the new instore position
-- and moves all items below the new position down 1 to make
-- room for the moved shopping list item
-- =============================================
CREATE PROCEDURE [dbo].[procShoppingListItemMove]
	@shoppingListItemID int
	,@newInStorePosition int
AS
BEGIN

	if @newInStorePosition < 1 begin
		set @newInStorePosition = 1
	end
	
	declare @moveShoppingListID int
	declare @currentInStorePosition int

	select
		@moveShoppingListID = item.shoppingListID
		,@currentInStorePosition = item.inStorePosition
	from 
		shoppingListItem item
	where 
		item.shoppingListItemID = @shoppingListItemID

	declare @lastInStorePosition int

	select	
		@lastInStorePosition = max(item.inStorePosition)
	from 
		shoppingListItem item
	where
		item.shoppingListID = @moveShoppingListID

	if @newInStorePosition > @lastInStorePosition begin
		set @newInStorePosition = @lastInStorePosition
	end

	declare @isMoveUp bit

	set @isMoveUp = iif(@newInStorePosition < @currentInStorePosition, 1, 0)

	-- move all shopping list items on or below the in store position 
	-- where  the item is being moved to down am in store position 
	-- in order to make room for the moved item
	update 
		item
	set 
		item.inStorePosition = iif(@isMoveUp = 1, item.inStorePosition + 1, item.inStorePosition - 1)
	from 
		shoppingListItem item
	where 
		item.shoppingListID = @moveShoppingListID
		and item.quantity > 0
		and 
		((item.inStorePosition between @newInStorePosition and @currentInStorePosition and @isMoveUp = 1)
		or (item.inStorePosition between @currentInStorePosition and @newInStorePosition and @isMoveUp = 0))

	update 
		item
	set 
		item.inStorePosition = @newInStorePosition
	from 
		shoppingListItem item
	where 
		item.shoppingListItemID = @shoppingListItemID

END

