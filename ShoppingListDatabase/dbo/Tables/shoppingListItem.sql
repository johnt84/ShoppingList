CREATE TABLE [dbo].[shoppingListItem] (
    [shoppingListItemID] INT             IDENTITY (1, 1) NOT NULL,
    [shoppingListID]     INT             NOT NULL,
    [itemName]           NVARCHAR (150)  NOT NULL,
    [price]              DECIMAL (18, 2) NOT NULL,
    [quantity]           INT             NOT NULL,
    [itemPicked]         BIT             NOT NULL,
    [inStorePosition]    INT             NOT NULL,
    CONSTRAINT [PK_shoppingListItem] PRIMARY KEY CLUSTERED ([shoppingListItemID] ASC)
);

