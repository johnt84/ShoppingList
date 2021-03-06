/****** Object:  StoredProcedure [dbo].[procShoppingListItemDelete]    Script Date: 09/08/2020 13:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Tomlinson
-- Create date: June 2020
-- Description:	Deletes an existing shopping list item
-- =============================================
ALTER PROCEDURE [dbo].[procShoppingListItemDelete]
	@shoppingListItemID int
AS
BEGIN

	declare @deleteShoppingListID int
	declare @deleteInStorePosition int

	select
		@deleteShoppingListID = item.shoppingListID
		,@deleteInStorePosition = item.inStorePosition
	from 
		shoppingListItem item
	where 
		item.shoppingListItemID = @shoppingListItemID
	
	delete
		item
	from 
		shoppingListItem item
	where 
		item.shoppingListItemID = @shoppingListItemID

	-- move all shopping list items below the deleted shopping list item
	-- in the same same shopping list up an in store position to fill 
	-- the removed shopping list item's in store position
	update 
		item
	set 
		item.inStorePosition = item.inStorePosition - 1
	from 
		shoppingListItem item
	where 
		item.shoppingListID = @deleteShoppingListID
		and item.inStorePosition > @deleteInStorePosition

END