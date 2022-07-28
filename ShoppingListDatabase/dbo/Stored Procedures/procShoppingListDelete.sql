-- =============================================
-- Author:		John Tomlinson
-- Create date: June 2020
-- Description:	Deletes an existing shopping list
-- =============================================
CREATE PROCEDURE [dbo].[procShoppingListDelete]
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

