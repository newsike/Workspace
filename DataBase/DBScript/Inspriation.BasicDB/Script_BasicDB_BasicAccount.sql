USE [Inspriation.BasicDB]
GO

/****** Object:  Table [dbo].[BasicDB_BasicAccount]    Script Date: 06/17/2014 15:56:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BasicDB_BasicAccount](
	[id] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[u_name] [nvarchar](50) NOT NULL,
	[u_password] [nvarchar](20) NOT NULL,
	[u_key] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BasicDB_BasicAccount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


