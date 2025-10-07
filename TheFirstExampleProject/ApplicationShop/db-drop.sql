USE [ShopDB]
GO

-- Drop foreign key constraints first
ALTER TABLE [dbo].[Basket] DROP CONSTRAINT [FK_Basket_Product1]
GO
ALTER TABLE [dbo].[Basket] DROP CONSTRAINT [FK_Basket_User]
GO
ALTER TABLE [dbo].[Login] DROP CONSTRAINT [FK_Login_User]
GO
ALTER TABLE [dbo].[Order_list] DROP CONSTRAINT [FK_Order_list_Order]
GO
ALTER TABLE [dbo].[Order_list] DROP CONSTRAINT [FK_Order_list_Product]
GO
ALTER TABLE [dbo].[Street] DROP CONSTRAINT [FK_Street_City]
GO
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[UserAdresses] DROP CONSTRAINT [FK_UserAdresses_Street]
GO
ALTER TABLE [dbo].[UserAdresses] DROP CONSTRAINT [FK_UserAdresses_User]
GO

-- Drop tables
DROP TABLE IF EXISTS [dbo].[Basket]
GO
DROP TABLE IF EXISTS [dbo].[City]
GO
DROP TABLE IF EXISTS [dbo].[Login]
GO
DROP TABLE IF EXISTS [dbo].[Order]
GO
DROP TABLE IF EXISTS [dbo].[Order_list]
GO
DROP TABLE IF EXISTS [dbo].[Product]
GO
DROP TABLE IF EXISTS [dbo].[Role]
GO
DROP TABLE IF EXISTS [dbo].[Street]
GO
DROP TABLE IF EXISTS [dbo].[User]
GO
DROP TABLE IF EXISTS [dbo].[UserAdresses]
GO

-- Drop user
DROP USER IF EXISTS [catshredia]
GO