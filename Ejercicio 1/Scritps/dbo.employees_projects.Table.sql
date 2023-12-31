USE [TestTreebu]
GO
/****** Object:  Table [dbo].[employees_projects]    Script Date: 6/12/2023 9:06:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees_projects](
	[project_id] [int] NOT NULL,
	[employee_id] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[employees_projects] ([project_id], [employee_id]) VALUES (2, 1)
INSERT [dbo].[employees_projects] ([project_id], [employee_id]) VALUES (3, 2)
INSERT [dbo].[employees_projects] ([project_id], [employee_id]) VALUES (1, 3)
INSERT [dbo].[employees_projects] ([project_id], [employee_id]) VALUES (1, 4)
INSERT [dbo].[employees_projects] ([project_id], [employee_id]) VALUES (1, 5)
GO
ALTER TABLE [dbo].[employees_projects]  WITH CHECK ADD  CONSTRAINT [FK_employees_projects_employees] FOREIGN KEY([employee_id])
REFERENCES [dbo].[employees] ([id])
GO
ALTER TABLE [dbo].[employees_projects] CHECK CONSTRAINT [FK_employees_projects_employees]
GO
ALTER TABLE [dbo].[employees_projects]  WITH CHECK ADD  CONSTRAINT [FK_employees_projects_projects] FOREIGN KEY([project_id])
REFERENCES [dbo].[projects] ([id])
GO
ALTER TABLE [dbo].[employees_projects] CHECK CONSTRAINT [FK_employees_projects_projects]
GO
