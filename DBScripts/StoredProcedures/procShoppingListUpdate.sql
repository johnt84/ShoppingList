/****** Object:  StoredProcedure [dbo].[procShoppingListUpdate]    Script Date: 09/08/2020 13:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Tomlinson
-- Create date: June 2020
-- Description:	Updates an existing shopping list
-- =============================================
ALTER PROCEDURE [dbo].[procShoppingListUpdate]
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

