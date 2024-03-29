USE [master]
GO
/****** Object:  Database [TurnosWeb]    Script Date: 14/11/2019 0:48:40 ******/
CREATE DATABASE [TurnosWeb]
 
-- ON  PRIMARY 
--( NAME = N'TurnosWeb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\TurnosWeb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'TurnosWeb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\TurnosWeb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )

GO
USE [TurnosWeb]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TurnosWeb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TurnosWeb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TurnosWeb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TurnosWeb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TurnosWeb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TurnosWeb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TurnosWeb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TurnosWeb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TurnosWeb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TurnosWeb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TurnosWeb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TurnosWeb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TurnosWeb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TurnosWeb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TurnosWeb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TurnosWeb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TurnosWeb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TurnosWeb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TurnosWeb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TurnosWeb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TurnosWeb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TurnosWeb] SET READ_COMMITTED_SNAPSHOT OFF 

GO
ALTER DATABASE [TurnosWeb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TurnosWeb] SET  MULTI_USER 
GO
ALTER DATABASE [TurnosWeb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TurnosWeb] SET DB_CHAINING OFF 


USE [TurnosWeb]
GO
/****** Object:  Table [dbo].[DuracionTurnos]    Script Date: 14/11/2019 0:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DuracionTurnos](
	[IdDuracionTurno] [smallint] NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[Minutos] [smallint] NOT NULL,
 CONSTRAINT [PK_DuracionTurnos] PRIMARY KEY CLUSTERED 
(
	[IdDuracionTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 14/11/2019 0:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresas](
	[IdEmpresa] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[EstadoActual] [smallint] NOT NULL,
	[RubroID] [smallint] NOT NULL,
	[Logo] [varbinary](max) NULL,
	[Direccion] [nvarchar](300) NOT NULL,
	[Latitud] [nvarchar](500) NOT NULL,
	[Longitud] [nvarchar](500) NOT NULL,
	[IdLocalidad] [smallint] NOT NULL,
	[FechaAlta] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresasServicios]    Script Date: 14/11/2019 0:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresasServicios](
	[IdServicio] [smallint] IDENTITY(1,1) NOT NULL,
	[IdEmpresa] [int] NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[PrecioSugerido] [money] NOT NULL,
	[IdDuracionTurno] [smallint] NOT NULL,
	[FechaAlta] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_EmpresasServicios] PRIMARY KEY CLUSTERED 
(
	[IdServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresasSubRubros]    Script Date: 14/11/2019 0:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresasSubRubros](
	[IdEmpresaSubRubro] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpresa] [int] NOT NULL,
	[SubRubroID] [int] NOT NULL,
 CONSTRAINT [PK_EmpresasSubRubros] PRIMARY KEY CLUSTERED 
(
	[IdEmpresaSubRubro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadosEmpresa]    Script Date: 14/11/2019 0:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadosEmpresa](
	[IdEstadoEmpresa] [smallint] NOT NULL,
	[DescripcionEstadoEmpresa] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 14/11/2019 0:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[IdLocalidad] [smallint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[IdLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 14/11/2019 0:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpresa] [int] NOT NULL,
	[IdDuracionTurno] [smallint] NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Lugar] [nvarchar](200) NOT NULL,
	[EstadoActual] [smallint] NOT NULL,
	[Celular] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonasServicios]    Script Date: 14/11/2019 0:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonasServicios](
	[IdPersonaServicio] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[IdServicio] [smallint] NULL,
	[PrecioSugerido] [money] NULL,
 CONSTRAINT [PK_PersonasServicios] PRIMARY KEY CLUSTERED 
(
	[IdPersonaServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rubros]    Script Date: 14/11/2019 0:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rubros](
	[RubroID] [smallint] NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Rubros] PRIMARY KEY CLUSTERED 
(
	[RubroID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubRubros]    Script Date: 14/11/2019 0:48:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubRubros](
	[SubRubroID] [int] IDENTITY(1,1) NOT NULL,
	[RubroID] [smallint] NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
 CONSTRAINT [PK_SubRubros] PRIMARY KEY CLUSTERED 
(
	[SubRubroID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empresas] ADD  DEFAULT ('') FOR [Direccion]
GO
ALTER TABLE [dbo].[Empresas] ADD  DEFAULT ('') FOR [Latitud]
GO
ALTER TABLE [dbo].[Empresas] ADD  DEFAULT ('') FOR [Longitud]
GO
ALTER TABLE [dbo].[Empresas] ADD  CONSTRAINT [DF_Empresas_IdLocalidad]  DEFAULT ((0)) FOR [IdLocalidad]
GO
ALTER TABLE [dbo].[Empresas] ADD  CONSTRAINT [DF_Empresas_FechaAlta]  DEFAULT (getdate()) FOR [FechaAlta]
GO
ALTER TABLE [dbo].[Personas] ADD  DEFAULT ('') FOR [Celular]
GO
ALTER TABLE [dbo].[Empresas]  WITH CHECK ADD  CONSTRAINT [FK_Empresas_Localidades] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[Empresas] CHECK CONSTRAINT [FK_Empresas_Localidades]
GO
ALTER TABLE [dbo].[Empresas]  WITH CHECK ADD  CONSTRAINT [FK_Empresas_Rubros] FOREIGN KEY([RubroID])
REFERENCES [dbo].[Rubros] ([RubroID])
GO
ALTER TABLE [dbo].[Empresas] CHECK CONSTRAINT [FK_Empresas_Rubros]
GO
ALTER TABLE [dbo].[EmpresasServicios]  WITH CHECK ADD  CONSTRAINT [FK_EmpresasServicios_DuracionTurnos] FOREIGN KEY([IdDuracionTurno])
REFERENCES [dbo].[DuracionTurnos] ([IdDuracionTurno])
GO
ALTER TABLE [dbo].[EmpresasServicios] CHECK CONSTRAINT [FK_EmpresasServicios_DuracionTurnos]
GO
ALTER TABLE [dbo].[EmpresasServicios]  WITH CHECK ADD  CONSTRAINT [FK_EmpresasServicios_Empresas] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresas] ([IdEmpresa])
GO
ALTER TABLE [dbo].[EmpresasServicios] CHECK CONSTRAINT [FK_EmpresasServicios_Empresas]
GO
ALTER TABLE [dbo].[EmpresasSubRubros]  WITH CHECK ADD  CONSTRAINT [FK_EmpresasSubRubros_Empresas] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresas] ([IdEmpresa])
GO
ALTER TABLE [dbo].[EmpresasSubRubros] CHECK CONSTRAINT [FK_EmpresasSubRubros_Empresas]
GO
ALTER TABLE [dbo].[EmpresasSubRubros]  WITH CHECK ADD  CONSTRAINT [FK_EmpresasSubRubros_SubRubros] FOREIGN KEY([SubRubroID])
REFERENCES [dbo].[SubRubros] ([SubRubroID])
GO
ALTER TABLE [dbo].[EmpresasSubRubros] CHECK CONSTRAINT [FK_EmpresasSubRubros_SubRubros]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_DuracionTurno] FOREIGN KEY([IdDuracionTurno])
REFERENCES [dbo].[DuracionTurnos] ([IdDuracionTurno])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_DuracionTurno]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Empresas] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresas] ([IdEmpresa])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Empresas]
GO
ALTER TABLE [dbo].[PersonasServicios]  WITH CHECK ADD  CONSTRAINT [FK_PersonasServicios_EmpresasServicios] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[EmpresasServicios] ([IdServicio])
GO
ALTER TABLE [dbo].[PersonasServicios] CHECK CONSTRAINT [FK_PersonasServicios_EmpresasServicios]
GO
ALTER TABLE [dbo].[PersonasServicios]  WITH CHECK ADD  CONSTRAINT [FK_PersonasServicios_Personas] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Personas] ([IdPersona])
GO
ALTER TABLE [dbo].[PersonasServicios] CHECK CONSTRAINT [FK_PersonasServicios_Personas]
GO
ALTER TABLE [dbo].[SubRubros]  WITH CHECK ADD  CONSTRAINT [FK_SubRubros_Rubros] FOREIGN KEY([RubroID])
REFERENCES [dbo].[Rubros] ([RubroID])
GO
ALTER TABLE [dbo].[SubRubros] CHECK CONSTRAINT [FK_SubRubros_Rubros]
GO
USE [master]
GO
ALTER DATABASE [TurnosWeb] SET  READ_WRITE 
GO
