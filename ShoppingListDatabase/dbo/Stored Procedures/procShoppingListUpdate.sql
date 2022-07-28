-- =============================================
-- Author:		John Tomlinson
-- Create date: June 2020
-- Description:	Updates an existing shopping list
-- =============================================
CREATE PROCEDURE [dbo].[procShoppingListUpdate]
	@shoppingListID int
	,@shoppingDate datetime
	,@totalAmount decimal(18, 2)
	,@userID int
AS
BEGIN
	
	update
		list
	set
		list.shoppingDate = @shoppingDate
		,list.totalAmount = @totalAmount
		,list.userID = @userID
	from 
		shoppingList list
	where 
		list.shoppingListID = @shoppingListID

END

