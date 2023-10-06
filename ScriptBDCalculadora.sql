USE [master]
GO
/****** Object:  Database [DB_Calculadora]    Script Date: 5/10/2023 7:49:52 p. m. ******/
CREATE DATABASE [DB_Calculadora]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Db_Calculadora', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Db_Calculadora.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Db_Calculadora_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Db_Calculadora_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DB_Calculadora] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Calculadora].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Calculadora] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Calculadora] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Calculadora] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Calculadora] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Calculadora] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Calculadora] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Calculadora] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Calculadora] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Calculadora] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Calculadora] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Calculadora] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Calculadora] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Calculadora] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Calculadora] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Calculadora] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_Calculadora] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Calculadora] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Calculadora] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Calculadora] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Calculadora] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Calculadora] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Calculadora] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Calculadora] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_Calculadora] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Calculadora] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Calculadora] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Calculadora] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Calculadora] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Calculadora] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Calculadora] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_Calculadora] SET QUERY_STORE = ON
GO
ALTER DATABASE [DB_Calculadora] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DB_Calculadora]
GO
/****** Object:  Table [dbo].[Historicos]    Script Date: 5/10/2023 7:49:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historicos](
	[idHistorico] [int] IDENTITY(1,1) NOT NULL,
	[historico] [nvarchar](max) NULL,
	[fecha] [date] NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Historicos] PRIMARY KEY CLUSTERED 
(
	[idHistorico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 5/10/2023 7:49:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[idLog] [int] IDENTITY(1,1) NOT NULL,
	[detalle] [nvarchar](max) NULL,
	[fecha] [date] NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[idLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Numeros]    Script Date: 5/10/2023 7:49:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Numeros](
	[idNumero] [int] IDENTITY(1,1) NOT NULL,
	[numero] [tinyint] NULL,
 CONSTRAINT [PK_Numeros] PRIMARY KEY CLUSTERED 
(
	[idNumero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operadores]    Script Date: 5/10/2023 7:49:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operadores](
	[idOperador] [int] IDENTITY(1,1) NOT NULL,
	[operador] [nchar](5) NULL,
	[idPrioridad] [int] NULL,
	[idUbicacion] [int] NULL,
 CONSTRAINT [PK_Operadores] PRIMARY KEY CLUSTERED 
(
	[idOperador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prioridades]    Script Date: 5/10/2023 7:49:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prioridades](
	[idPrioridades] [int] IDENTITY(1,1) NOT NULL,
	[prioridad] [nchar](10) NULL,
 CONSTRAINT [PK_Prioridades] PRIMARY KEY CLUSTERED 
(
	[idPrioridades] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubicaciones]    Script Date: 5/10/2023 7:49:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubicaciones](
	[idUbicacion] [int] IDENTITY(1,1) NOT NULL,
	[ubicacion] [nchar](10) NULL,
 CONSTRAINT [PK_Ubicaciones] PRIMARY KEY CLUSTERED 
(
	[idUbicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 5/10/2023 7:49:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Historicos] ON 
GO
INSERT [dbo].[Historicos] ([idHistorico], [historico], [fecha], [idUsuario]) VALUES (1, N'2+2=4', CAST(N'2023-10-05' AS Date), 1)
GO
INSERT [dbo].[Historicos] ([idHistorico], [historico], [fecha], [idUsuario]) VALUES (2, N'2*2=4', CAST(N'2023-10-05' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[Historicos] OFF
GO
SET IDENTITY_INSERT [dbo].[Logs] ON 
GO
INSERT [dbo].[Logs] ([idLog], [detalle], [fecha]) VALUES (1, N'Usuario: Jay Crea Operacion: 2+2', CAST(N'2023-10-05' AS Date))
GO
INSERT [dbo].[Logs] ([idLog], [detalle], [fecha]) VALUES (2, N'Usuario: Jay Elimina Registro ', CAST(N'2023-10-05' AS Date))
GO
INSERT [dbo].[Logs] ([idLog], [detalle], [fecha]) VALUES (5, N'Usuario : Jay Crear Operacion: 2+2+4=8 idHistorico: 5', CAST(N'2023-10-05' AS Date))
GO
INSERT [dbo].[Logs] ([idLog], [detalle], [fecha]) VALUES (6, N'Usuario : Jay Elimina Operacion: 2+2+4=8 idHistorico: 5', CAST(N'2023-10-05' AS Date))
GO
INSERT [dbo].[Logs] ([idLog], [detalle], [fecha]) VALUES (7, N'Usuario : Jay Crear Operacion: 2+2+4=8 idHistorico: 6', CAST(N'2023-10-05' AS Date))
GO
INSERT [dbo].[Logs] ([idLog], [detalle], [fecha]) VALUES (8, N'Usuario : Jay Elimina Operacion: 2+2+4=8 idHistorico: 6', CAST(N'2023-10-05' AS Date))
GO
INSERT [dbo].[Logs] ([idLog], [detalle], [fecha]) VALUES (9, N'Usuario : Jay Crear Operacion: 2+2+4+2=10 idHistorico: 7', CAST(N'2023-10-05' AS Date))
GO
INSERT [dbo].[Logs] ([idLog], [detalle], [fecha]) VALUES (10, N'Usuario : Jay Elimina Operacion: 2+2+4+2=10 idHistorico: 7', CAST(N'2023-10-05' AS Date))
GO
INSERT [dbo].[Logs] ([idLog], [detalle], [fecha]) VALUES (11, N'Usuario : Jay Crear Operacion: 2+2+4+2=10 idHistorico: 9', CAST(N'2023-10-05' AS Date))
GO
INSERT [dbo].[Logs] ([idLog], [detalle], [fecha]) VALUES (13, N'Usuario : Jay Elimina Operacion: 2+2+4+2=10 idHistorico: 9', CAST(N'2023-10-05' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Logs] OFF
GO
SET IDENTITY_INSERT [dbo].[Numeros] ON 
GO
INSERT [dbo].[Numeros] ([idNumero], [numero]) VALUES (1, 0)
GO
INSERT [dbo].[Numeros] ([idNumero], [numero]) VALUES (2, 1)
GO
INSERT [dbo].[Numeros] ([idNumero], [numero]) VALUES (3, 2)
GO
INSERT [dbo].[Numeros] ([idNumero], [numero]) VALUES (4, 3)
GO
INSERT [dbo].[Numeros] ([idNumero], [numero]) VALUES (5, 4)
GO
INSERT [dbo].[Numeros] ([idNumero], [numero]) VALUES (6, 5)
GO
INSERT [dbo].[Numeros] ([idNumero], [numero]) VALUES (7, 6)
GO
INSERT [dbo].[Numeros] ([idNumero], [numero]) VALUES (8, 7)
GO
INSERT [dbo].[Numeros] ([idNumero], [numero]) VALUES (9, 8)
GO
INSERT [dbo].[Numeros] ([idNumero], [numero]) VALUES (10, 9)
GO
SET IDENTITY_INSERT [dbo].[Numeros] OFF
GO
SET IDENTITY_INSERT [dbo].[Operadores] ON 
GO
INSERT [dbo].[Operadores] ([idOperador], [operador], [idPrioridad], [idUbicacion]) VALUES (1, N'+    ', 4, 2)
GO
INSERT [dbo].[Operadores] ([idOperador], [operador], [idPrioridad], [idUbicacion]) VALUES (2, N'-    ', 4, 2)
GO
INSERT [dbo].[Operadores] ([idOperador], [operador], [idPrioridad], [idUbicacion]) VALUES (3, N'*    ', 3, 2)
GO
INSERT [dbo].[Operadores] ([idOperador], [operador], [idPrioridad], [idUbicacion]) VALUES (4, N'/    ', 3, 2)
GO
SET IDENTITY_INSERT [dbo].[Operadores] OFF
GO
SET IDENTITY_INSERT [dbo].[Prioridades] ON 
GO
INSERT [dbo].[Prioridades] ([idPrioridades], [prioridad]) VALUES (1, N'Alta      ')
GO
INSERT [dbo].[Prioridades] ([idPrioridades], [prioridad]) VALUES (2, N'Media     ')
GO
INSERT [dbo].[Prioridades] ([idPrioridades], [prioridad]) VALUES (3, N'Normal    ')
GO
INSERT [dbo].[Prioridades] ([idPrioridades], [prioridad]) VALUES (4, N'Baja      ')
GO
SET IDENTITY_INSERT [dbo].[Prioridades] OFF
GO
SET IDENTITY_INSERT [dbo].[Ubicaciones] ON 
GO
INSERT [dbo].[Ubicaciones] ([idUbicacion], [ubicacion]) VALUES (1, N'Top       ')
GO
INSERT [dbo].[Ubicaciones] ([idUbicacion], [ubicacion]) VALUES (2, N'Right     ')
GO
INSERT [dbo].[Ubicaciones] ([idUbicacion], [ubicacion]) VALUES (3, N'Bottom    ')
GO
INSERT [dbo].[Ubicaciones] ([idUbicacion], [ubicacion]) VALUES (4, N'Left      ')
GO
SET IDENTITY_INSERT [dbo].[Ubicaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([idUsuario], [usuario]) VALUES (1, N'Jay')
GO
INSERT [dbo].[Usuarios] ([idUsuario], [usuario]) VALUES (2, N'Joseph')
GO
INSERT [dbo].[Usuarios] ([idUsuario], [usuario]) VALUES (3, N'Richard')
GO
INSERT [dbo].[Usuarios] ([idUsuario], [usuario]) VALUES (4, N'Larry')
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Historicos]  WITH CHECK ADD  CONSTRAINT [FK_Historicos_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Historicos] CHECK CONSTRAINT [FK_Historicos_Usuarios]
GO
ALTER TABLE [dbo].[Operadores]  WITH CHECK ADD  CONSTRAINT [FK_Operadores_Prioridades] FOREIGN KEY([idPrioridad])
REFERENCES [dbo].[Prioridades] ([idPrioridades])
GO
ALTER TABLE [dbo].[Operadores] CHECK CONSTRAINT [FK_Operadores_Prioridades]
GO
ALTER TABLE [dbo].[Operadores]  WITH CHECK ADD  CONSTRAINT [FK_Operadores_Ubicaciones] FOREIGN KEY([idUbicacion])
REFERENCES [dbo].[Ubicaciones] ([idUbicacion])
GO
ALTER TABLE [dbo].[Operadores] CHECK CONSTRAINT [FK_Operadores_Ubicaciones]
GO
/****** Object:  StoredProcedure [dbo].[GetHistoricos]    Script Date: 5/10/2023 7:49:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetHistoricos]
as
Select * 
From Historicos h 
join Usuarios u on h.idUsuario = u.idUsuario
GO
/****** Object:  Trigger [dbo].[Historicos_Delete]    Script Date: 5/10/2023 7:49:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Historicos_Delete]
ON [dbo].[Historicos]
FOR DELETE
AS
   INSERT INTO Logs(detalle, fecha)
   SELECT  'Usuario : ' + (Select top(1) u.usuario from Usuarios U where u.idUsuario = idUsuario ) + ' Elimina Operacion: ' + historico + ' idHistorico: ' + convert(varchar(10), idHistorico),GETDATE()
   FROM DELETED;
GO
ALTER TABLE [dbo].[Historicos] ENABLE TRIGGER [Historicos_Delete]
GO
/****** Object:  Trigger [dbo].[Historicos_Insert]    Script Date: 5/10/2023 7:49:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Historicos_Insert]
ON [dbo].[Historicos]
AFTER INSERT
AS
   INSERT INTO Logs(detalle, fecha)
   SELECT  'Usuario : ' + (Select top(1) u.usuario from Usuarios U where u.idUsuario = idUsuario ) + ' Crear Operacion: ' + historico + ' idHistorico: ' + convert(varchar(10), idHistorico),GETDATE()
   FROM INSERTED;
GO
ALTER TABLE [dbo].[Historicos] ENABLE TRIGGER [Historicos_Insert]
GO
USE [master]
GO
ALTER DATABASE [DB_Calculadora] SET  READ_WRITE 
GO
