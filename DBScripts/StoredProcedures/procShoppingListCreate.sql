/****** Object:  StoredProcedure [dbo].[procShoppingListCreate]    Script Date: 09/08/2020 13:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Tomlinson
-- Create date: June 2020
-- Description:	Creates a new shopping list
-- =============================================
ALTER PROCEDURE [dbo].[procShoppingListCreate]
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

