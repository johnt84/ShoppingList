/****** Object:  StoredProcedure [dbo].[procShoppingListBulkCopy]    Script Date: 09/08/2020 13:18:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Tomlinson
-- Create date: June 2020
-- Description:	Copies existing shopping list items into
-- a newly created shopping list
-- =============================================
ALTER PROCEDURE [dbo].[procShoppingListBulkCopy]
	@NewShoppingListID int
	,@CopyShoppingListID int
AS
BEGIN
	
	if not exists(
		select *
		from shoppingList list
		where list.shoppingListID = @NewShoppingListID
	)
	begin
		return
	end

	if not exists(
		select *
		from shoppingList list
		where list.shoppingListID = @CopyShoppingListID
	)
	begin
		return
	end

	insert into shoppingListItem
	(
		shoppingListID
		,itemName
		,price
		,quantity
		,itemPicked
		,inStorePosition
	)
	select 
		@NewShoppingListID
		,copyItems.itemName
		,isnull(latestItemPrice.price, 0) as estimatedPrice
		,copyItems.quantity
		,0
		,copyItems.inStorePosition
	from 
		shoppingListItem copyItems
	left join latestItemPrice on copyItems.itemName = latestItemPrice.itemName
	where 
		copyItems.shoppingListID = @CopyShoppingListID

END
