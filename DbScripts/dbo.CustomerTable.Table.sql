SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerTable](
	[CustomerId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](1000) NULL,
	[CustomerEmail] [varchar](600) NULL,
	[CustomerPhone] [varchar](100) NULL,
 CONSTRAINT [PK_CustomerTable] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
