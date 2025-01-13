USE [master]
GO
/****** Object:  Database [ProductsCategoriesSystem]    Script Date: 1/10/2025 6:46:01 PM ******/
CREATE DATABASE [ProductsCategoriesSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductsCategoriesSystem', FILENAME = N'C:\Users\Ahmed.sakr\ProductsCategoriesSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductsCategoriesSystem_log', FILENAME = N'C:\Users\Ahmed.sakr\ProductsCategoriesSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProductsCategoriesSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductsCategoriesSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductsCategoriesSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET  MULTI_USER 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductsCategoriesSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProductsCategoriesSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProductsCategoriesSystem] SET QUERY_STORE = OFF
GO
USE [ProductsCategoriesSystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/10/2025 6:46:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 1/10/2025 6:46:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ParentCategoryId] [uniqueidentifier] NULL,
	[Status] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 1/10/2025 6:46:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[Status] [int] NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Categories_ParentCategoryId]    Script Date: 1/10/2025 6:46:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Categories_ParentCategoryId] ON [dbo].[Categories]
(
	[ParentCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 1/10/2025 6:46:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories_ParentCategoryId] FOREIGN KEY([ParentCategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories_ParentCategoryId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [ProductsCategoriesSystem] SET  READ_WRITE 
GO
