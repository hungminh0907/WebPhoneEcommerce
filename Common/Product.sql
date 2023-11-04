USE [PhoneEcommerce]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 10/17/2023 10:32:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Id] [nvarchar](100) primary key,
	[ProductId] [nvarchar](20) NULL,
	[ProductName] [nvarchar](100) NULL,
	[Description] [nvarchar](255) NULL,
	[UnitPrice] [numeric](28, 8) NULL,
	[Filter] [nvarchar](255) NULL,
	[Urlimg] [nvarchar](255) NULL
) ON [PRIMARY]

GO
GO
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice],  [Filter]) VALUES (N'3079d92c-b605-486d-a682-7d7a41905a9f', 'IP-X', N'IPhone X', N'Đen', '10050000')
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice],  [Filter]) VALUES (N'4c3d87d1-3d0d-41ee-847e-b0f46a70a241', 'IP-11', N'IPhone 11', N'Đen', '13050000')
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice],  [Filter]) VALUES (N'4d7434b6-638c-4ced-8e6d-bb720d4cf45f', 'IP-12', N'IPhone 12', N'Vàng Gold', '13450000')
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice],  [Filter]) VALUES (N'7248e558-2e17-470c-a637-9fa86852769f', 'IP-13', N'IPhone 13', N'Đen', '13450000')
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice],  [Filter]) VALUES (N'b40f8a03-0c27-45f7-a571-774ee6f6c2be', 'IP-14', N'IPhone 14', N'Blue', '13450000')
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice],  [Filter]) VALUES (N'bdd72a1c-d03d-492e-a302-407e600bf4ba', 'IP-14Pro', N'IPhone 14 Pro', N'Đen', '12450000')
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice],  [Filter]) VALUES (N'c09e6a9f-7b58-44ee-975b-4fb8e3420f29', 'IP-13Pro', N'IPhone 13 Pro', N'Đen', '13500000')
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice],  [Filter]) VALUES (N'ca6b0995-c761-4351-b9a2-beecad5a3bcc', 'IP-13ProMax', N'IPhone 13 Pro Max', N'Đen Blue', '13250000')
INSERT [dbo].[Product] ([Id], [ProductId], [ProductName], [Description], [UnitPrice],  [Filter]) VALUES (N'ea94be2b-9056-4475-9923-8cbb7350ee38', 'IP-14ProMax', N'IPhone 14 Pro Max', N'Đen Blue', '13650000')
GO
alter table Product add primary key (Id)
ALTER TABLE Product ALTER COLUMN Id nvarchar(100) NOT NULL

