CREATE TABLE [dbo].[shoppingList] (
    [shoppingListID] INT             IDENTITY (1, 1) NOT NULL,
    [shoppingDate]   DATETIME        NOT NULL,
    [totalAmount]    DECIMAL (18, 2) NOT NULL,
    [dateCreated]    DATETIME        NOT NULL,
    [userID]         INT             NULL,
    CONSTRAINT [PK_shoppingList] PRIMARY KEY CLUSTERED ([shoppingListID] ASC)
);

