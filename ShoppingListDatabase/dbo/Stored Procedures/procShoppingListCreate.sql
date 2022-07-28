-- =============================================
-- Author:		John Tomlinson
-- Create date: June 2020
-- Description:	Creates a new shopping list
-- =============================================
CREATE PROCEDURE [dbo].[procShoppingListCreate]
	@shoppingDate datetime
	,@totalAmount decimal(18, 2)
	,@userID int
	,@copyShoppingListID int
AS
BEGIN
	
	begin transaction

	insert into shoppingList
	(
		shoppingDate
		, totalAmount
		, dateCreated
		, userID
	)
	values
	(
		@shoppingDate
		,@totalAmount
		,getutcdate()
		,@userID
	)

	declare @newShoppingListID int

	select @newShoppingListID = SCOPE_IDENTITY()

	if @copyShoppingListID > 0
	begin
		exec procShoppingListBulkCopy @newShoppingListID, @copyShoppingListID
	end
 
	commit

	select @newShoppingListID

END

