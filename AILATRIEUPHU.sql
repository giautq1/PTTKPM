USE master
GO
drop DATABASE [AILATRIEUPHU2]
GO
CREATE DATABASE [AILATRIEUPHU2]
GO
USE [AILATRIEUPHU]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [int] IDENTITY(1,5) NOT NULL,
	[Fullname] [nvarchar](300) NULL,
	[Username] [varchar](100) NOT NULL,
	[Password] [varchar](500) NOT NULL,
	[Type] [int] NOT NULL,
	[Createdate] [datetime] NULL,
	[Lastlogin] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[Type] [int] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[IsAdmin] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Answer]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[AnswerID] [int] IDENTITY(1,5) NOT NULL,
	[QuestionID] [int] NOT NULL,
	[Content] [nvarchar](500) NULL,
	[AnswerLevel] [int] NOT NULL,
	[IsResult] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[AnswerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[History]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[HistoryID] [int] IDENTITY(1,5) NOT NULL,
	[AccountID] [int] NOT NULL,
	[Level] [int] NULL,
	[Total] [money] NULL,
	[Createdate] [datetime] NULL,
	[Finishdate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[HistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HistoryDetail]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryDetail](
	[DetailID] [int] IDENTITY(1,5) NOT NULL,
	[HistoryID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[AnswerID] [int] NOT NULL,
	[Createdate] [datetime] NULL,
	[Finishdate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Point]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Point](
	[PointID] [int] IDENTITY(1,5) NOT NULL,
	[Level] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PointID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PrizeMoney]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrizeMoney](
	[Level] [int] NOT NULL,
	[Money] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Level] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionID] [int] IDENTITY(1,5) NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
	[Level] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountID], [Fullname], [Username], [Password], [Type], [Createdate], [Lastlogin]) VALUES (16, N'admin', N'admin', N'c4ca4238a0b923820dcc509a6f75849b', 2, NULL, CAST(N'2018-11-19 11:14:31.530' AS DateTime))
INSERT [dbo].[Account] ([AccountID], [Fullname], [Username], [Password], [Type], [Createdate], [Lastlogin]) VALUES (21, N'HoangCP', N'HoangCP', N'c4ca4238a0b923820dcc509a6f75849b', 1, NULL, CAST(N'2018-11-19 13:41:22.910' AS DateTime))
INSERT [dbo].[Account] ([AccountID], [Fullname], [Username], [Password], [Type], [Createdate], [Lastlogin]) VALUES (26, N'Chế Phi Hoàng', N'cphoang', N'c4ca4238a0b923820dcc509a6f75849b', 2, NULL, CAST(N'2018-11-19 21:47:39.517' AS DateTime))
SET IDENTITY_INSERT [dbo].[Account] OFF
INSERT [dbo].[AccountType] ([Type], [Description], [IsAdmin]) VALUES (1, N'Admin', 1)
INSERT [dbo].[AccountType] ([Type], [Description], [IsAdmin]) VALUES (2, N'Quản lý', 0)
INSERT [dbo].[AccountType] ([Type], [Description], [IsAdmin]) VALUES (3, N'Người dùng', 0)
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (1, 16, N'Thóc', 1, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (6, 16, N'Lúa', 2, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (11, 16, N'Gạo', 3, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (16, 16, N'Cơm', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (21, 21, N'Nếp', 1, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (26, 21, N'Gạo', 2, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (31, 21, N'Khoai lan', 3, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (36, 21, N'Sắn', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (41, 26, N'Hội Gióng', 1, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (46, 26, N'Hội Linh', 2, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (51, 26, N'Hội Liêm', 3, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (56, 26, N'Hội Lim', 4, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (61, 31, N'Chết nằm', 1, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (66, 31, N'Gió mạnh', 2, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (71, 31, N'Chết đứng', 3, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (76, 31, N'Gió to', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (81, 36, N'Châu Âu', 1, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (86, 36, N'Châu Á', 2, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (91, 36, N'Châu Phi', 3, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (96, 36, N'Châu Mỹ', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (101, 41, N'Núi Bà Đen', 1, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (106, 41, N'Dãy Hoàng Liên Sơn', 2, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (111, 41, N'Núi Cấm', 3, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (116, 41, N'Fansipan', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (121, 46, N'Trần Thủ Độ', 1, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (126, 46, N'Ngô Quyền', 2, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (131, 46, N'Nguyễn Huệ', 3, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (136, 46, N'Trần Quốc Toản', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (141, 51, N'Pháp', 1, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (146, 51, N'Nam Phi', 2, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (151, 51, N'Ba Lan', 3, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (156, 51, N'Mexico', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (161, 56, N'Piano', 1, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (166, 56, N'Violin', 2, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (171, 56, N'Sáo', 3, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (176, 56, N'Đàn tranh', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (181, 61, N'Rạch Gầm', 1, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (186, 61, N'Sài Gòn', 2, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (191, 61, N'Điện Biên Phủ', 3, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (196, 61, N'Ba Son', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (201, 66, N'Vua Trần Thái Tông', 1, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (206, 66, N'Vua Tự Đức', 2, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (211, 66, N'Vua Quan Trung', 3, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (216, 66, N'Vua Bảo Đại', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (221, 71, N'Quảng Ninh', 1, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (226, 71, N'Quảng Nam', 2, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (231, 71, N'Quảng Bình', 3, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (236, 71, N'Quảng Ngãi', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (241, 76, N'Lý Thái Tổ', 1, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (246, 76, N'Lý Thái Tông', 2, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (251, 76, N'Lý Nhân Tông', 3, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (256, 76, N'Trần Nhân Tông', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (261, 81, N'28-10-1892', 1, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (266, 81, N'10-10-1892', 2, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (271, 81, N'10-10-1890', 3, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (276, 81, N'28-10-1982', 4, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (281, 86, N'Báo người lao động', 1, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (286, 86, N'Báo tuổi trẻ', 2, NULL)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (291, 86, N'Báo tuổi trẻ cười', 3, 1)
INSERT [dbo].[Answer] ([AnswerID], [QuestionID], [Content], [AnswerLevel], [IsResult]) VALUES (296, 86, N'Báo phụ nữ', 4, NULL)
SET IDENTITY_INSERT [dbo].[Answer] OFF
SET IDENTITY_INSERT [dbo].[History] ON 

INSERT [dbo].[History] ([HistoryID], [AccountID], [Level], [Total], [Createdate], [Finishdate]) VALUES (1, 21, 0, 0.0000, CAST(N'2018-11-19 13:39:43.273' AS DateTime), NULL)
INSERT [dbo].[History] ([HistoryID], [AccountID], [Level], [Total], [Createdate], [Finishdate]) VALUES (6, 21, 4, 0.0000, CAST(N'2018-11-19 13:41:24.103' AS DateTime), CAST(N'2018-11-19 13:42:13.437' AS DateTime))
INSERT [dbo].[History] ([HistoryID], [AccountID], [Level], [Total], [Createdate], [Finishdate]) VALUES (11, 21, 6, 2000000.0000, CAST(N'2018-11-19 13:42:48.900' AS DateTime), CAST(N'2018-11-19 13:43:59.577' AS DateTime))
INSERT [dbo].[History] ([HistoryID], [AccountID], [Level], [Total], [Createdate], [Finishdate]) VALUES (16, 26, 8, 2000000.0000, CAST(N'2018-11-19 13:47:05.060' AS DateTime), CAST(N'2018-11-19 13:49:05.063' AS DateTime))
INSERT [dbo].[History] ([HistoryID], [AccountID], [Level], [Total], [Createdate], [Finishdate]) VALUES (21, 26, 2, 0.0000, CAST(N'2018-11-19 21:45:11.437' AS DateTime), CAST(N'2018-11-19 21:45:53.810' AS DateTime))
SET IDENTITY_INSERT [dbo].[History] OFF
SET IDENTITY_INSERT [dbo].[HistoryDetail] ON 

INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (6, 6, 31, 71, CAST(N'2018-11-19 13:41:24.953' AS DateTime), CAST(N'2018-11-19 13:41:45.630' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (11, 6, 16, 11, CAST(N'2018-11-19 13:41:47.713' AS DateTime), CAST(N'2018-11-19 13:41:51.410' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (16, 6, 21, 26, CAST(N'2018-11-19 13:41:53.477' AS DateTime), CAST(N'2018-11-19 13:41:57.060' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (21, 6, 26, 56, CAST(N'2018-11-19 13:41:59.127' AS DateTime), CAST(N'2018-11-19 13:42:02.970' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (26, 6, 86, 281, CAST(N'2018-11-19 13:42:05.037' AS DateTime), CAST(N'2018-11-19 13:42:11.400' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (31, 11, 31, 71, CAST(N'2018-11-19 13:42:49.320' AS DateTime), CAST(N'2018-11-19 13:43:08.843' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (36, 11, 16, 11, CAST(N'2018-11-19 13:43:10.940' AS DateTime), CAST(N'2018-11-19 13:43:14.400' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (41, 11, 21, 26, CAST(N'2018-11-19 13:43:16.463' AS DateTime), CAST(N'2018-11-19 13:43:20.263' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (46, 11, 26, 56, CAST(N'2018-11-19 13:43:22.327' AS DateTime), CAST(N'2018-11-19 13:43:25.760' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (51, 11, 86, 291, CAST(N'2018-11-19 13:43:27.813' AS DateTime), CAST(N'2018-11-19 13:43:34.717' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (56, 11, 36, 81, CAST(N'2018-11-19 13:43:42.810' AS DateTime), CAST(N'2018-11-19 13:43:57.537' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (61, 16, 31, 71, CAST(N'2018-11-19 13:47:05.827' AS DateTime), CAST(N'2018-11-19 13:47:24.710' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (66, 16, 16, 11, CAST(N'2018-11-19 13:47:26.790' AS DateTime), CAST(N'2018-11-19 13:47:29.920' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (71, 16, 21, 26, CAST(N'2018-11-19 13:47:32.003' AS DateTime), CAST(N'2018-11-19 13:47:34.867' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (76, 16, 26, 56, CAST(N'2018-11-19 13:47:36.920' AS DateTime), CAST(N'2018-11-19 13:47:40.460' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (81, 16, 86, 291, CAST(N'2018-11-19 13:47:42.530' AS DateTime), CAST(N'2018-11-19 13:47:46.380' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (86, 16, 36, 91, CAST(N'2018-11-19 13:47:54.463' AS DateTime), CAST(N'2018-11-19 13:48:39.967' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (91, 16, 41, 106, CAST(N'2018-11-19 13:48:42.053' AS DateTime), CAST(N'2018-11-19 13:48:51.993' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (96, 16, 46, 131, CAST(N'2018-11-19 13:48:54.060' AS DateTime), CAST(N'2018-11-19 13:49:03.013' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (101, 21, 31, 71, CAST(N'2018-11-19 21:45:13.523' AS DateTime), CAST(N'2018-11-19 21:45:39.833' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (106, 21, 16, 11, CAST(N'2018-11-19 21:45:41.943' AS DateTime), CAST(N'2018-11-19 21:45:46.617' AS DateTime))
INSERT [dbo].[HistoryDetail] ([DetailID], [HistoryID], [QuestionID], [AnswerID], [Createdate], [Finishdate]) VALUES (111, 21, 21, 31, CAST(N'2018-11-19 21:45:48.680' AS DateTime), CAST(N'2018-11-19 21:45:51.763' AS DateTime))
SET IDENTITY_INSERT [dbo].[HistoryDetail] OFF
SET IDENTITY_INSERT [dbo].[Point] ON 

INSERT [dbo].[Point] ([PointID], [Level]) VALUES (1, 5)
INSERT [dbo].[Point] ([PointID], [Level]) VALUES (6, 10)
INSERT [dbo].[Point] ([PointID], [Level]) VALUES (11, 15)
SET IDENTITY_INSERT [dbo].[Point] OFF
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (1, 200000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (2, 400000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (3, 600000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (4, 1000000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (5, 2000000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (6, 3000000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (7, 6000000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (8, 10000000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (9, 14000000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (10, 22000000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (11, 30000000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (12, 40000000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (13, 60000000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (14, 85000000.0000)
INSERT [dbo].[PrizeMoney] ([Level], [Money]) VALUES (15, 100000000.0000)
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (16, N'Mạnh vì..., bạo vì tiền', 2)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (21, N'Thức ăn nào sau đây thuộc nhóm thức ăn chứa nhiều bột đường', 3)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (26, N'Hội hát quan họ nào được tổ chức từ 11 - 13 tháng Giêng Âm lịch hàng năm?', 4)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (31, N'Cây ngay không sợ...', 1)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (36, N'Sau chiến tranh thế giới 2, phong trào giải phóng dân tộc nổi lên mạnh nhất ở đâu?', 6)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (41, N'Miền núi có các vành đai thực vật theo độ cao, phong phú nhất nước ta?', 7)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (46, N'Câu nói: "Đầu tôi chưa rơi xuống đất, xin bệ hạ đừng lo" là của ai?', 8)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (51, N'Quốc kỳ nào giống hệt quốc kỳ Indonexia nhưng ngược chiều', 9)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (56, N'Nhạc sĩ Sô Panh gắn liền với nhạc cụ nào?', 10)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (61, N'Lần đầu tiên nước ta dùng bộc phá 1000kg thuốc nổ đánh giặc là ở đâu? ', 11)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (66, N'Ở Chùa Bộc, ngoài thờ phật, nhân dân còn thờ vị tướng nào?', 12)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (71, N'Kinh thành trà kiệu thuộc tỉnh nào? ', 13)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (76, N'Vua nào đặt nhiều niên hiệu nhất lịch sử nước ta?', 14)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (81, N'Phim hoạt hình đầu tiên được công chiếu vào thời gian nào?', 15)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (86, N'Giải thưởng "Cù Nèo Vàng" dành cho nghệ sĩ hài được cơ quan nào trao tặng?', 5)
INSERT [dbo].[Question] ([QuestionID], [Content], [Level]) VALUES (121, N'ád', 1)
SET IDENTITY_INSERT [dbo].[Question] OFF
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_AccountType] FOREIGN KEY([Type])
REFERENCES [dbo].[AccountType] ([Type])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_AccountType]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Question] ([QuestionID])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Account]
GO
ALTER TABLE [dbo].[HistoryDetail]  WITH CHECK ADD  CONSTRAINT [FK_HistoryDetail_History] FOREIGN KEY([HistoryID])
REFERENCES [dbo].[History] ([HistoryID])
GO
ALTER TABLE [dbo].[HistoryDetail] CHECK CONSTRAINT [FK_HistoryDetail_History]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_PrizeMoney] FOREIGN KEY([Level])
REFERENCES [dbo].[PrizeMoney] ([Level])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_PrizeMoney]
GO
/****** Object:  StoredProcedure [dbo].[CheckAnswer]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[CheckAnswer]
	@QuestionID INT,
	@AnswerLevel INT,
	@Result INT OUT	
AS BEGIN
	IF EXISTS (SELECT AnswerID FROM Answer WHERE QuestionID=@QuestionID AND AnswerLevel = @AnswerLevel AND IsResult=1)
	BEGIN
		SET @Result = 1
	END
	ELSE	 
	BEGIN
		SET @Result = 0 		
	END
END


GO
/****** Object:  StoredProcedure [dbo].[CreateQuestion]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CreateQuestion]
	@Content nvarchar(1000), 
	@Level int, 
	@AnswerA nvarchar(1000), 
	@AnswerB nvarchar(1000), 
	@AnswerC nvarchar(1000), 
	@AnswerD nvarchar(1000), 
	@IsResult int,
	@Result int OUTPUT
AS BEGIN
	SET @Result = 0
	BEGIN TRANSACTION
		INSERT INTO Question(Content, Level)
		VALUES(@Content, @Level)
		DECLARE @QuestionID int = @@IDENTITY
	
		INSERT INTO Answer(QuestionID, Content, AnswerLevel)
		SELECT @QuestionID, @AnswerA, 1
		UNION ALL
		SELECT @QuestionID, @AnswerB, 2
		UNION ALL
		SELECT @QuestionID, @AnswerC, 3
		UNION ALL
		SELECT @QuestionID, @AnswerD, 4

		UPDATE Answer
		SET IsResult = 1
		WHERE QuestionID=@QuestionID AND AnswerLevel=@IsResult

		SET @Result = 1
	COMMIT TRANSACTION
END


GO
/****** Object:  StoredProcedure [dbo].[GetListHistory]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetListHistory]
	@AccountID INT
AS BEGIN
	SELECT TOP(10)*FROM(
	SELECT ROW_NUMBER() OVER(ORDER BY Createdate ASC) STT
		, HistoryID, AccountID, Createdate, Finishdate, Level, Total 
	FROM History 
	where AccountID=@AccountID) AS Main
	ORDER BY STT DESC	
END

GO
/****** Object:  StoredProcedure [dbo].[GetQuestionLevel]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetQuestionLevel]
	@Level INT
AS BEGIN		
	SELECT TOP(1) QuestionID, Content, Level, 
	MAX(CASE AnswerLevel WHEN 1 THEN AnswerContent END) AnswerA,
	MAX(CASE AnswerLevel WHEN 2 THEN AnswerContent END) AnswerB,
	MAX(CASE AnswerLevel WHEN 3 THEN AnswerContent END) AnswerC,
	MAX(CASE AnswerLevel WHEN 4 THEN AnswerContent END) AnswerD,
	MAX(CASE IsResult WHEN 1 THEN AnswerLevel END) Result
	FROM (
	SELECT A.QuestionID, A.Content, A.Level, B.AnswerID, B.Content AnswerContent, B.AnswerLevel, CASE B.IsResult WHEN 1 THEN '1' ELSE '0' END IsResult
	FROM Question AS A
	INNER JOIN (SELECT*FROM Answer)AS B ON B.QuestionID = A.QuestionID	
	WHERE A.Level = @Level
	) AS Main
	GROUP BY QuestionID, Content, Level
	ORDER BY NEWID()
END


GO
/****** Object:  StoredProcedure [dbo].[Logging]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Logging]
	@Username varchar(100),
	@Password varchar(500)
AS BEGIN 
	SELECT*FROM Account WHERE Username=@Username and Password=@Password
	IF @@ROWCOUNT >0
		UPDATE Account SET Lastlogin=GETDATE() WHERE Username=@Username
END

GO
/****** Object:  StoredProcedure [dbo].[Register]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Register]
	@Fullname nvarchar(50),
	@Username varchar(100),
	@Password varchar(500),
	@Result INT OUTPUT
AS BEGIN
	IF NOT EXISTS (SELECT AccountID FROM Account WHERE Username=@Username)
	BEGIN
		INSERT INTO Account (Fullname, Username, Password, Type)
		VALUES (@Fullname, @Username, @Password, 2)
		SET @Result = 1
	END
	ELSE
	BEGIN
		SET @Result = 2
	END
END

GO
/****** Object:  StoredProcedure [dbo].[Support5050]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Support5050]
	@QuestionID INT
AS BEGIN
	SELECT AnswerLevel
	FROM Answer 
	WHERE QuestionID=@QuestionID AND ISNULL(IsResult,0)= 1
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateHistory]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateHistory]
	@HistoryID INT = 0,
	@AccountID INT,
	@Level INT,
	@Total money,	
	@Type INT,
	@HistoryIDOUT INT OUTPUT
AS BEGIN
	IF NOT EXISTS (SELECT HistoryID FROM History WHERE HistoryID=@HistoryID)
	BEGIN
		INSERT INTO History(AccountID, Level, Total, Createdate)
		VALUES (@AccountID, @Level, @Total, GETDATE())

		SET @HistoryIDOUT = @@IDENTITY
	END
	ELSE
	BEGIN		
		IF @Type = 1 --Nhấn nút stop
			SET @Level = @Level -1
		ELSE IF @Type = 2 --Trả lời sai
		BEGIN		
			IF @Level <= 5		
			BEGIN
				SET @Level = @Level -1
				SET @Total = 0		
			END
			ELSE
			BEGIN
				DECLARE @LevelTemp INT
				SELECT TOP(1) @LevelTemp=Level FROM Point WHERE Level < @Level ORDER BY Level DESC
				Select @Total = Money from PrizeMoney where Level=@LevelTemp
			END
		END
		ELSE IF @Type = 3 --Trả đến câu cuối cùng
			SET @Level = @Level

		IF @Type <> 2
			Select @Total = Money from PrizeMoney where Level=@Level

		UPDATE History
		SET Level = @Level, Total = @Total, Finishdate = GETDATE()
		WHERE HistoryID=@HistoryID

		SET @HistoryIDOUT =0
	END
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateHistoryDetail]    Script Date: 11/19/2018 09:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[UpdateHistoryDetail]
	@DetailID INT = 0,
	@HistoryID INT,
	@QuestionID INT,
	@AnswerLevel INT,
	@DetailIDOUT INT OUTPUT	
AS BEGIN
	IF NOT EXISTS (SELECT DetailID FROM HistoryDetail WHERE DetailID=@DetailID) OR @DetailID <=0
	BEGIN
		INSERT INTO HistoryDetail(HistoryID, QuestionID, AnswerID, Createdate)
		VALUES (@HistoryID, @QuestionID, 0, GETDATE())

		SET @DetailIDOUT = @@IDENTITY
	END
	ELSE
	BEGIN
		DECLARE @AnswerID INT
		SELECT @AnswerID = AnswerID FROM Answer WHERE QuestionID=@QuestionID AND AnswerLevel=@AnswerLevel

		UPDATE HistoryDetail
		SET AnswerID=@AnswerID,
			Finishdate = GETDATE()
		WHERE DetailID=@DetailID

		SET @DetailIDOUT =0
	END
END


GO
