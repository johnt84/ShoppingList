/****** Object:  StoredProcedure [dbo].[procShoppingListDelete]    Script Date: 09/08/2020 13:17:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Tomlinson
-- Create date: June 2020
-- Description:	Deletes an existing shopping list
-- =============================================
ALTER PROCEDURE [dbo].[procShoppingListDelete]
	@shoppingListID int
AS
BEGIN
	
	delete
		list
	from 
		shoppingList list
	where 
		list.shoppingListID = @shoppingListID

END

