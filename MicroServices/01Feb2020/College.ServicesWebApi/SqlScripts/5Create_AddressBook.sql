USE [webapidemo]
GO

/****** Object:  Table [dbo].[AddressBook]    Script Date: 2/2/2020 2:15:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AddressBook](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NULL,
	[Address] [varchar](150) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AddressBook] ADD  CONSTRAINT [DF_AddressBook_Id]  DEFAULT (newid()) FOR [Id]
GO


