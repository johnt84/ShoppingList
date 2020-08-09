/****** Object:  View [dbo].[latestItemPrice]    Script Date: 09/08/2020 13:15:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[latestItemPrice] AS

select 
	item.itemName
	,latestItemPrice.price
from 
	shoppinglistitem item
inner join
(
	select 
		row_number() over(partition by item.itemName order by item.shoppingListID desc) rownum
		,item.*
	from 
		shoppingListItem item
	where 
		item.quantity > 0 
		and item.price > 0
)latestItemPrice on item.shoppingListItemID = latestItemPrice.shoppingListItemID and latestItemPrice.rownum = 1
GO


