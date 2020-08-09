/****** Object:  Table [dbo].[shoppingList]    Script Date: 09/08/2020 13:14:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[shoppingList](
	[shoppingListID] [int] IDENTITY(1,1) NOT NULL,
	[shoppingDate] [datetime] NOT NULL,
	[totalAmount] [decimal](18, 2) NOT NULL,
	[dateCreated] [datetime] NOT NULL,
	[userID] [int] NULL,
 CONSTRAINT [PK_shoppingList] PRIMARY KEY CLUSTERED 
(
	[shoppingListID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


