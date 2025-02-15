USE [MVCExamen]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 1/09/2024 17:57:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Productos]') AND type in (N'U'))
DROP TABLE [dbo].[Productos]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 1/09/2024 17:57:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ProductoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([ProductoID], [Nombre], [Precio], [FechaVencimiento]) VALUES (1, N'Gaseosa Coca Cola', CAST(5.00 AS Decimal(10, 2)), CAST(N'2024-09-04' AS Date))
INSERT [dbo].[Productos] ([ProductoID], [Nombre], [Precio], [FechaVencimiento]) VALUES (2, N'Gaseosa Inka Kola', CAST(5.00 AS Decimal(10, 2)), CAST(N'2024-09-01' AS Date))
INSERT [dbo].[Productos] ([ProductoID], [Nombre], [Precio], [FechaVencimiento]) VALUES (3, N'Gaseosa Kola Real', CAST(4.00 AS Decimal(10, 2)), CAST(N'2024-09-01' AS Date))
INSERT [dbo].[Productos] ([ProductoID], [Nombre], [Precio], [FechaVencimiento]) VALUES (4, N'Galleta Club Social', CAST(1.00 AS Decimal(10, 2)), CAST(N'2024-09-01' AS Date))
INSERT [dbo].[Productos] ([ProductoID], [Nombre], [Precio], [FechaVencimiento]) VALUES (6, N'Galleta Soda Field', CAST(3.00 AS Decimal(10, 2)), CAST(N'2024-09-30' AS Date))
INSERT [dbo].[Productos] ([ProductoID], [Nombre], [Precio], [FechaVencimiento]) VALUES (7, N'Galleta Vainilla Field', CAST(3.00 AS Decimal(10, 2)), CAST(N'2024-09-30' AS Date))
INSERT [dbo].[Productos] ([ProductoID], [Nombre], [Precio], [FechaVencimiento]) VALUES (8, N'Galleta Margarita', CAST(3.00 AS Decimal(10, 2)), CAST(N'2024-09-30' AS Date))
INSERT [dbo].[Productos] ([ProductoID], [Nombre], [Precio], [FechaVencimiento]) VALUES (9, N'Galleta Soda San Jorge', CAST(3.00 AS Decimal(10, 2)), CAST(N'2024-10-01' AS Date))
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
