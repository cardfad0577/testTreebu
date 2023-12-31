USE [TestTreebu]
GO
/****** Object:  Table [dbo].[projects]    Script Date: 6/12/2023 9:06:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[projects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](255) NOT NULL,
	[star_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[budget] [int] NOT NULL,
 CONSTRAINT [PK_projects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[projects] ON 

INSERT [dbo].[projects] ([id], [title], [star_date], [end_date], [budget]) VALUES (1, N'Build a cool site', CAST(N'2011-10-28' AS Date), CAST(N'2012-01-26' AS Date), 1000000)
INSERT [dbo].[projects] ([id], [title], [star_date], [end_date], [budget]) VALUES (2, N'Update TPS Reports', CAST(N'2011-07-20' AS Date), CAST(N'2011-10-28' AS Date), 100000)
INSERT [dbo].[projects] ([id], [title], [star_date], [end_date], [budget]) VALUES (3, N'Design 3 New Silly Walks', CAST(N'2009-05-11' AS Date), CAST(N'2009-08-19' AS Date), 100)
SET IDENTITY_INSERT [dbo].[projects] OFF
GO
