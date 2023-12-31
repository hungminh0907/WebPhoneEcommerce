USE [PhoneEcommerce]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/24/2023 3:51:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [nvarchar](100) NULL,
	[ProductId] [nvarchar](20) NULL,
	[ProductName] [nvarchar](100) NULL,
	[Description] [nvarchar](255) NULL,
	[UnitPrice] [numeric](28, 8) NULL,
	[Filter] [nvarchar](255) NULL,
	[Urlimg] [nvarchar](250) NULL
) ON [PRIMARY]

GO
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice], [Filter], [Urlimg]) VALUES (N'265120b1-f73a-4a1b-b5cb-64041274b716', N'test1', N'test1', N'test1', CAST(12345.00000000 AS Numeric(28, 8)), N'test1 test1 test1', N'\img\5577be57-de37-4f21-9523-d9ceea0d41be-iphone3.jfif')
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice], [Filter], [Urlimg]) VALUES (N'4c3d87d1-3d0d-41ee-847e-b0f46a70a241', N'IP-11', N'IPhone 11', N'Đen', CAST(13050000.00000000 AS Numeric(28, 8)), N'ip-11_iphone 11_đen', NULL)
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice], [Filter], [Urlimg]) VALUES (N'4d7434b6-638c-4ced-8e6d-bb720d4cf45f', N'IP-12', N'IPhone 12', N'Vàng Gold', CAST(13450000.00000000 AS Numeric(28, 8)), N'ip-12_iphone 12_vàng gold', NULL)
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice], [Filter], [Urlimg]) VALUES (N'7248e558-2e17-470c-a637-9fa86852769f', N'IP-13', N'IPhone 13', N'Đen', CAST(13450000.00000000 AS Numeric(28, 8)), N'ip-13_iphone 13_đen', NULL)
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice], [Filter], [Urlimg]) VALUES (N'b40f8a03-0c27-45f7-a571-774ee6f6c2be', N'IP-14', N'IPhone 14', N'Blue', CAST(13450000.00000000 AS Numeric(28, 8)), N'ip-14_iphone 14_blue', NULL)
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice], [Filter], [Urlimg]) VALUES (N'bdd72a1c-d03d-492e-a302-407e600bf4ba', N'IP-14Pro', N'IPhone 14 Pro', N'Đen', CAST(12450000.00000000 AS Numeric(28, 8)), N'ip-14pro_iphone 14 pro_đen', NULL)
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice], [Filter], [Urlimg]) VALUES (N'c09e6a9f-7b58-44ee-975b-4fb8e3420f29', N'IP-13Pro', N'IPhone 13 Pro', N'Đen', CAST(13500000.00000000 AS Numeric(28, 8)), N'ip-13pro_iphone 13 pro_đen', NULL)
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice], [Filter], [Urlimg]) VALUES (N'ca6b0995-c761-4351-b9a2-beecad5a3bcc', N'IP-13ProMax', N'IPhone 13 Pro Max', N'Đen Blue', CAST(13250000.00000000 AS Numeric(28, 8)), N'ip-13promax_iphone 13 pro max_đen blue', NULL)
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice], [Filter], [Urlimg]) VALUES (N'ea94be2b-9056-4475-9923-8cbb7350ee38', N'IP-14ProMax', N'IPhone 14 Pro Max', N'Đen Blue', CAST(13650000.00000000 AS Numeric(28, 8)), N'ip-14promax_iphone 14 pro max_đen blue', NULL)
