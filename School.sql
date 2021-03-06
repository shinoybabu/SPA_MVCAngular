CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Age] [int] NULL,
	[Gender] [nvarchar](10) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[studentDetail]    Script Date: 5/28/2016 7:42:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[studentDetail](
	[StudentDetailID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NULL,
	[Address1] [nvarchar](500) NULL,
	[Address2] [nvarchar](500) NULL,
	[Married] [bit] NULL,
 CONSTRAINT [PK_studentDetail] PRIMARY KEY CLUSTERED 
(
	[StudentDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID], [FirstName], [LastName], [Age], [Gender]) VALUES (1, N'Shinoy', N'Babu', 35, N'Male')
INSERT [dbo].[Student] ([ID], [FirstName], [LastName], [Age], [Gender]) VALUES (2, N'Amritha', N'Chandrasekharan', 28, N'Female')
INSERT [dbo].[Student] ([ID], [FirstName], [LastName], [Age], [Gender]) VALUES (3, N'Binoy', N'Babu', 35, N'Male')
INSERT [dbo].[Student] ([ID], [FirstName], [LastName], [Age], [Gender]) VALUES (17, N'Rejeesh', N'Veetil', 32, N'Male')
INSERT [dbo].[Student] ([ID], [FirstName], [LastName], [Age], [Gender]) VALUES (18, N'Test 88', N'Test', 45, N'Male')
INSERT [dbo].[Student] ([ID], [FirstName], [LastName], [Age], [Gender]) VALUES (19, N'Test 88', N'dd', 55, N'Male')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[studentDetail] ON 

INSERT [dbo].[studentDetail] ([StudentDetailID], [StudentID], [Address1], [Address2], [Married]) VALUES (1, 1, N'Address 1', N'Address 2', 1)
INSERT [dbo].[studentDetail] ([StudentDetailID], [StudentID], [Address1], [Address2], [Married]) VALUES (2, 1, N'Address 2', N'Address 2', 1)
INSERT [dbo].[studentDetail] ([StudentDetailID], [StudentID], [Address1], [Address2], [Married]) VALUES (3, 1, N'Address 3', N'Address 3', 1)
INSERT [dbo].[studentDetail] ([StudentDetailID], [StudentID], [Address1], [Address2], [Married]) VALUES (4, 1, N'test', N'ddd', 1)
INSERT [dbo].[studentDetail] ([StudentDetailID], [StudentID], [Address1], [Address2], [Married]) VALUES (5, 1, N'test', N'afsdasd', 1)
INSERT [dbo].[studentDetail] ([StudentDetailID], [StudentID], [Address1], [Address2], [Married]) VALUES (6, 2, N'Address 1', N'Address 2', 1)
INSERT [dbo].[studentDetail] ([StudentDetailID], [StudentID], [Address1], [Address2], [Married]) VALUES (7, 2, N'Address 2', N'Address 2', 0)
INSERT [dbo].[studentDetail] ([StudentDetailID], [StudentID], [Address1], [Address2], [Married]) VALUES (8, 2, N'Address 3', N'Address 3', 0)
INSERT [dbo].[studentDetail] ([StudentDetailID], [StudentID], [Address1], [Address2], [Married]) VALUES (9, 4, N'Address 4', N'Address 4', 0)
INSERT [dbo].[studentDetail] ([StudentDetailID], [StudentID], [Address1], [Address2], [Married]) VALUES (10, 17, N'Address 1', N'Address 1', 0)
INSERT [dbo].[studentDetail] ([StudentDetailID], [StudentID], [Address1], [Address2], [Married]) VALUES (11, 17, N'Address 2', N'Address 2', 0)
SET IDENTITY_INSERT [dbo].[studentDetail] OFF
USE [master]
GO
ALTER DATABASE [School] SET  READ_WRITE 
GO
