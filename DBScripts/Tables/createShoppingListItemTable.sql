/****** Object:  Table [dbo].[shoppingListItem]    Script Date: 09/08/2020 13:15:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[shoppingListItem](
	[shoppingListItemID] [int] IDENTITY(1,1) NOT NULL,
	[shoppingListID] [int] NOT NULL,
	[itemName] [nvarchar](150) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[quantity] [int] NOT NULL,
	[itemPicked] [bit] NOT NULL,
	[inStorePosition] [int] NOT NULL,
 CONSTRAINT [PK_shoppingListItem] PRIMARY KEY CLUSTERED 
(
	[shoppingListItemID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


