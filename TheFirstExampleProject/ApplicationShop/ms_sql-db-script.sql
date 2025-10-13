-- Drop =============================================================================
USE [ShopDB]
GO

-- Drop foreign key constraints first (in reverse order of creation)
ALTER TABLE [dbo].[RolePermission] DROP CONSTRAINT [FK_RolePermission_Role]
    GO

ALTER TABLE [dbo].[UserAdresses] DROP CONSTRAINT [FK_UserAdresses_Street]
    GO
ALTER TABLE [dbo].[UserAdresses] DROP CONSTRAINT [FK_UserAdresses_User]
    GO

ALTER TABLE [dbo].[Login] DROP CONSTRAINT [FK_Login_User]
    GO

ALTER TABLE [dbo].[Basket] DROP CONSTRAINT [FK_Basket_User]
    GO
ALTER TABLE [dbo].[Basket] DROP CONSTRAINT [FK_Basket_Product1]
    GO

ALTER TABLE [dbo].[Order_list] DROP CONSTRAINT [FK_Order_list_Order]
    GO
ALTER TABLE [dbo].[Order_list] DROP CONSTRAINT [FK_Order_list_Product]
    GO

ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_User]
    GO

ALTER TABLE [dbo].[Street] DROP CONSTRAINT [FK_Street_City]
    GO

ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Role]
    GO

-- Drop tables (in reverse dependency order)
DROP TABLE IF EXISTS [dbo].[RolePermission]
    GO
DROP TABLE IF EXISTS [dbo].[Login]
    GO
DROP TABLE IF EXISTS [dbo].[Basket]
    GO
DROP TABLE IF EXISTS [dbo].[Order_list]
    GO
DROP TABLE IF EXISTS [dbo].[Order]
    GO
DROP TABLE IF EXISTS [dbo].[UserAdresses]
    GO
DROP TABLE IF EXISTS [dbo].[Street]
    GO
DROP TABLE IF EXISTS [dbo].[City]
    GO
DROP TABLE IF EXISTS [dbo].[Product]
    GO
DROP TABLE IF EXISTS [dbo].[User]
    GO
DROP TABLE IF EXISTS [dbo].[Role]
    GO

-- Optional: Drop user if it exists
DROP USER IF EXISTS [catshredia]
GO
     
-- Create =============================================================================

USE [master]
GO

-- Create database
-- CREATE DATABASE [ShopDB]
--  CONTAINMENT = NONE
--  ON PRIMARY 
-- ( NAME = N'ShopDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ShopDB.mdf', SIZE = 8192KB, MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
--  LOG ON 
-- ( NAME = N'ShopDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ShopDB_log.ldf', SIZE = 8192KB, MAXSIZE = 2048GB, FILEGROWTH = 65536KB )
-- GO

-- ALTER DATABASE [ShopDB] SET COMPATIBILITY_LEVEL = 140
-- GO
-- ALTER DATABASE [ShopDB] SET RECOVERY SIMPLE
-- GO
-- ALTER DATABASE [ShopDB] SET READ_WRITE
-- GO

USE [ShopDB]
GO

-- Tables
CREATE TABLE [dbo].[Role](
	[id_role] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([id_role])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[City](
	[id_city] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([id_city])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Street](
	[id_street] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[id_city] [int] NOT NULL,
 CONSTRAINT [PK_Street] PRIMARY KEY CLUSTERED ([id_street])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[User](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[surname] [varchar](50) NULL,
	[name] [varchar](50) NOT NULL,
	[description] [text] NULL,
	[phone] [varchar](50) NULL,
	[id_role] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([id_user])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[UserAdresses](
	[id_user_adress] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[id_street] [int] NOT NULL,
	[home] [varchar](3) NOT NULL,
	[apartment] [int] NULL,
 CONSTRAINT [PK_UserAdresses] PRIMARY KEY CLUSTERED ([id_user_adress])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Login](
	[id_login] [int] IDENTITY(1,1) NOT NULL,
	[login] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[id_user] [int] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([id_login])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Product](
	[id_product] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[price] [int] NOT NULL,
	[provider] [varchar](50) NULL,
	[image_path] [varchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([id_product])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Basket](
	[id_basket] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[id_product] [int] NOT NULL,
	[count] [int] NOT NULL CONSTRAINT [DF_Basket_count] DEFAULT ((0)),
 CONSTRAINT [PK_Basket] PRIMARY KEY CLUSTERED ([id_basket])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Order](
	[id_order] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,          -- ✅ FIXED: Added missing user reference
	[is_paided] [bit] NOT NULL,
	[is_delivered] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([id_order])
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Order_list](
	[id_order_list] [int] IDENTITY(1,1) NOT NULL,
	[id_order] [int] NOT NULL,
	[id_product] [int] NOT NULL,
 CONSTRAINT [PK_Order_list_1] PRIMARY KEY CLUSTERED ([id_order_list])
) ON [PRIMARY]
GO

-- Role-based permissions table (for dynamic UI control)
CREATE TABLE [dbo].[RolePermission](
	[id_role] [int] NOT NULL,
	[permission_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RolePermission] PRIMARY KEY ([id_role], [permission_name])
) ON [PRIMARY]
GO

-- Foreign Keys
ALTER TABLE [dbo].[Street] ADD CONSTRAINT [FK_Street_City] FOREIGN KEY([id_city]) REFERENCES [dbo].[City]([id_city]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [dbo].[User] ADD CONSTRAINT [FK_User_Role] FOREIGN KEY([id_role]) REFERENCES [dbo].[Role]([id_role]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [dbo].[UserAdresses] ADD CONSTRAINT [FK_UserAdresses_Street] FOREIGN KEY([id_street]) REFERENCES [dbo].[Street]([id_street]) ON UPDATE CASCADE ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAdresses] ADD CONSTRAINT [FK_UserAdresses_User] FOREIGN KEY([id_user]) REFERENCES [dbo].[User]([id_user]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Login] ADD CONSTRAINT [FK_Login_User] FOREIGN KEY([id_user]) REFERENCES [dbo].[User]([id_user]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Basket] ADD CONSTRAINT [FK_Basket_User] FOREIGN KEY([id_user]) REFERENCES [dbo].[User]([id_user]) ON UPDATE CASCADE ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Basket] ADD CONSTRAINT [FK_Basket_Product1] FOREIGN KEY([id_product]) REFERENCES [dbo].[Product]([id_product]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Order] ADD CONSTRAINT [FK_Order_User] FOREIGN KEY([id_user]) REFERENCES [dbo].[User]([id_user]) ON UPDATE CASCADE ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Order_list] ADD CONSTRAINT [FK_Order_list_Order] FOREIGN KEY([id_order]) REFERENCES [dbo].[Order]([id_order])
GO
ALTER TABLE [dbo].[Order_list] ADD CONSTRAINT [FK_Order_list_Product] FOREIGN KEY([id_product]) REFERENCES [dbo].[Product]([id_product])
GO

ALTER TABLE [dbo].[RolePermission] ADD CONSTRAINT [FK_RolePermission_Role] FOREIGN KEY([id_role]) REFERENCES [dbo].[Role]([id_role]) ON DELETE CASCADE
GO