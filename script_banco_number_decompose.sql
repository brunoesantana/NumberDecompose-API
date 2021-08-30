USE [master]
GO

/****** Object:  Database [number_decompose]    Script Date: 30/08/2021 00:49:44 ******/
CREATE DATABASE [number_decompose]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'number_decompose', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\number_decompose.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'number_decompose_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\number_decompose_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [number_decompose].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [number_decompose] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [number_decompose] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [number_decompose] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [number_decompose] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [number_decompose] SET ARITHABORT OFF 
GO

ALTER DATABASE [number_decompose] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [number_decompose] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [number_decompose] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [number_decompose] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [number_decompose] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [number_decompose] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [number_decompose] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [number_decompose] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [number_decompose] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [number_decompose] SET  DISABLE_BROKER 
GO

ALTER DATABASE [number_decompose] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [number_decompose] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [number_decompose] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [number_decompose] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [number_decompose] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [number_decompose] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [number_decompose] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [number_decompose] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [number_decompose] SET  MULTI_USER 
GO

ALTER DATABASE [number_decompose] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [number_decompose] SET DB_CHAINING OFF 
GO

ALTER DATABASE [number_decompose] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [number_decompose] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [number_decompose] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [number_decompose] SET QUERY_STORE = OFF
GO

ALTER DATABASE [number_decompose] SET  READ_WRITE 
GO

USE [number_decompose]
GO

/****** Object:  Table [dbo].[Number]    Script Date: 30/08/2021 00:50:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Number](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[Date] [datetime] NOT NULL,
	[Version] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[Value] [int] NOT NULL
) ON [PRIMARY]
GO
