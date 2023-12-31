USE [TestTreebu]
GO
/****** Object:  Table [dbo].[departments]    Script Date: 6/12/2023 9:06:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_departments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[departments] ON 

INSERT [dbo].[departments] ([id], [name]) VALUES (1, N'Reporting')
INSERT [dbo].[departments] ([id], [name]) VALUES (2, N'Engineering')
INSERT [dbo].[departments] ([id], [name]) VALUES (3, N'Marketing')
INSERT [dbo].[departments] ([id], [name]) VALUES (4, N'Biz Dev')
INSERT [dbo].[departments] ([id], [name]) VALUES (5, N'Silly Walks')
SET IDENTITY_INSERT [dbo].[departments] OFF
GO
