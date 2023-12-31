USE [TestTreebu]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 6/12/2023 9:06:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](255) NOT NULL,
	[last_name] [varchar](255) NOT NULL,
	[salary] [int] NOT NULL,
	[department_id] [int] NOT NULL,
 CONSTRAINT [PK_employees] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[employees] ON 

INSERT [dbo].[employees] ([id], [first_name], [last_name], [salary], [department_id]) VALUES (1, N'John', N'Smith', 20000, 1)
INSERT [dbo].[employees] ([id], [first_name], [last_name], [salary], [department_id]) VALUES (2, N'Ava', N'Muffinson', 10000, 5)
INSERT [dbo].[employees] ([id], [first_name], [last_name], [salary], [department_id]) VALUES (3, N'Cailin', N'Ninson', 30000, 2)
INSERT [dbo].[employees] ([id], [first_name], [last_name], [salary], [department_id]) VALUES (4, N'Mike', N'Peterson', 20000, 2)
INSERT [dbo].[employees] ([id], [first_name], [last_name], [salary], [department_id]) VALUES (5, N'Ian', N'Peterson', 80000, 2)
INSERT [dbo].[employees] ([id], [first_name], [last_name], [salary], [department_id]) VALUES (6, N'John', N'Mills', 50000, 3)
SET IDENTITY_INSERT [dbo].[employees] OFF
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_departments] FOREIGN KEY([department_id])
REFERENCES [dbo].[departments] ([id])
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_departments]
GO
