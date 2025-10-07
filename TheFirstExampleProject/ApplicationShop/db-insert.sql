USE [ShopDB]
GO

-- Roles (6 roles)
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([id_role], [name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([id_role], [name]) VALUES (2, N'Manager')
INSERT [dbo].[Role] ([id_role], [name]) VALUES (3, N'Employee')
INSERT [dbo].[Role] ([id_role], [name]) VALUES (4, N'Customer')
INSERT [dbo].[Role] ([id_role], [name]) VALUES (5, N'Support')
INSERT [dbo].[Role] ([id_role], [name]) VALUES (6, N'Guest')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO

-- Role Permissions
INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (1, N'Employee')
INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (1, N'Users')
INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (1, N'Product')
INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (1, N'OrderList')
INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (1, N'Catalog')

INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (2, N'Users')
INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (2, N'Product')
INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (2, N'OrderList')

INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (3, N'Product')
INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (3, N'OrderList')

INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (4, N'Catalog')
INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (4, N'OrderList')

INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (5, N'Users')
INSERT [dbo].[RolePermission] ([id_role], [permission_name]) VALUES (5, N'OrderList')

-- Guest has no permissions
GO

-- Cities (6 cities)
SET IDENTITY_INSERT [dbo].[City] ON
INSERT [dbo].[City] ([id_city], [name]) VALUES (1, N'Moscow')
INSERT [dbo].[City] ([id_city], [name]) VALUES (2, N'Saint Petersburg')
INSERT [dbo].[City] ([id_city], [name]) VALUES (3, N'Novosibirsk')
INSERT [dbo].[City] ([id_city], [name]) VALUES (4, N'Yekaterinburg')
INSERT [dbo].[City] ([id_city], [name]) VALUES (5, N'Kazan')
INSERT [dbo].[City] ([id_city], [name]) VALUES (6, N'Nizhny Novgorod')
SET IDENTITY_INSERT [dbo].[City] OFF
GO

-- Streets (6 streets — 1 per city)
SET IDENTITY_INSERT [dbo].[Street] ON
INSERT [dbo].[Street] ([id_street], [name], [id_city]) VALUES (1, N'Tverskaya', 1)
INSERT [dbo].[Street] ([id_street], [name], [id_city]) VALUES (2, N'Nevsky Prospect', 2)
INSERT [dbo].[Street] ([id_street], [name], [id_city]) VALUES (3, N'Krasny Avenue', 3)
INSERT [dbo].[Street] ([id_street], [name], [id_city]) VALUES (4, N'Lenina Street', 4)
INSERT [dbo].[Street] ([id_street], [name], [id_city]) VALUES (5, N'Bauman Street', 5)
INSERT [dbo].[Street] ([id_street], [name], [id_city]) VALUES (6, N'Bolshaya Pokrovskaya', 6)
SET IDENTITY_INSERT [dbo].[Street] OFF
GO

-- Users (6 users — one per role)
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([id_user], [surname], [name], [description], [phone], [id_role]) 
VALUES (1, N'Ivanov', N'Ivan', N'System admin', N'+79001111111', 1)

INSERT [dbo].[User] ([id_user], [surname], [name], [description], [phone], [id_role]) 
VALUES (2, N'Petrov', N'Petr', N'Store manager', N'+79002222222', 2)

INSERT [dbo].[User] ([id_user], [surname], [name], [description], [phone], [id_role]) 
VALUES (3, N'Sidorov', N'Sergey', N'Warehouse employee', N'+79003333333', 3)

INSERT [dbo].[User] ([id_user], [surname], [name], [description], [phone], [id_role]) 
VALUES (4, N'Kuznetsova', N'Anna', N'Regular customer', N'+79004444444', 4)

INSERT [dbo].[User] ([id_user], [surname], [name], [description], [phone], [id_role]) 
VALUES (5, N'Morozov', N'Dmitry', N'Support specialist', N'+79005555555', 5)

INSERT [dbo].[User] ([id_user], [surname], [name], [description], [phone], [id_role]) 
VALUES (6, N'Guest', N'User', N'Guest account', NULL, 6)
SET IDENTITY_INSERT [dbo].[User] OFF
GO

-- User Addresses (6 addresses — one per user)
SET IDENTITY_INSERT [dbo].[UserAdresses] ON
INSERT [dbo].[UserAdresses] ([id_user_adress], [id_user], [id_street], [home], [apartment]) 
VALUES (1, 1, 1, N'10', 5)
INSERT [dbo].[UserAdresses] ([id_user_adress], [id_user], [id_street], [home], [apartment]) 
VALUES (2, 2, 2, N'25', 12)
INSERT [dbo].[UserAdresses] ([id_user_adress], [id_user], [id_street], [home], [apartment]) 
VALUES (3, 3, 3, N'50', 3)
INSERT [dbo].[UserAdresses] ([id_user_adress], [id_user], [id_street], [home], [apartment]) 
VALUES (4, 4, 4, N'77', 21)
INSERT [dbo].[UserAdresses] ([id_user_adress], [id_user], [id_street], [home], [apartment]) 
VALUES (5, 5, 5, N'33', 8)
INSERT [dbo].[UserAdresses] ([id_user_adress], [id_user], [id_street], [home], [apartment]) 
VALUES (6, 6, 6, N'1', NULL) -- Guest has no apartment
SET IDENTITY_INSERT [dbo].[UserAdresses] OFF
GO

-- Logins (6 logins — one per user)
SET IDENTITY_INSERT [dbo].[Login] ON
INSERT [dbo].[Login] ([id_login], [login], [password], [id_user]) 
VALUES (1, N'admin', N'admin123', 1)
INSERT [dbo].[Login] ([id_login], [login], [password], [id_user]) 
VALUES (2, N'manager', N'manager123', 2)
INSERT [dbo].[Login] ([id_login], [login], [password], [id_user]) 
VALUES (3, N'employee', N'emp123', 3)
INSERT [dbo].[Login] ([id_login], [login], [password], [id_user]) 
VALUES (4, N'customer', N'cust123', 4)
INSERT [dbo].[Login] ([id_login], [login], [password], [id_user]) 
VALUES (5, N'support', N'supp123', 5)
INSERT [dbo].[Login] ([id_login], [login], [password], [id_user]) 
VALUES (6, N'guest', N'guest123', 6)
SET IDENTITY_INSERT [dbo].[Login] OFF
GO

-- Products (6 products)
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT [dbo].[Product] ([id_product], [name], [price], [provider], [image_path]) 
VALUES (1, N'Laptop', 50000, N'Dell', N'/images/laptop.jpg')
INSERT [dbo].[Product] ([id_product], [name], [price], [provider], [image_path]) 
VALUES (2, N'Mouse', 1500, N'Logitech', N'/images/mouse.jpg')
INSERT [dbo].[Product] ([id_product], [name], [price], [provider], [image_path]) 
VALUES (3, N'Keyboard', 2500, N'Razer', N'/images/keyboard.jpg')
INSERT [dbo].[Product] ([id_product], [name], [price], [provider], [image_path]) 
VALUES (4, N'Monitor', 12000, N'Samsung', N'/images/monitor.jpg')
INSERT [dbo].[Product] ([id_product], [name], [price], [provider], [image_path]) 
VALUES (5, N'Headphones', 3500, N'Sony', N'/images/headphones.jpg')
INSERT [dbo].[Product] ([id_product], [name], [price], [provider], [image_path]) 
VALUES (6, N'Webcam', 4000, N'Logitech', N'/images/webcam.jpg')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO

-- Orders (6 orders — mostly for customer & manager)
SET IDENTITY_INSERT [dbo].[Order] ON
INSERT [dbo].[Order] ([id_order], [id_user], [is_paided], [is_delivered]) VALUES (1, 4, 1, 1) -- Customer
INSERT [dbo].[Order] ([id_order], [id_user], [is_paided], [is_delivered]) VALUES (2, 4, 1, 0)
INSERT [dbo].[Order] ([id_order], [id_user], [is_paided], [is_delivered]) VALUES (3, 2, 1, 1) -- Manager
INSERT [dbo].[Order] ([id_order], [id_user], [is_paided], [is_delivered]) VALUES (4, 2, 0, 0)
INSERT [dbo].[Order] ([id_order], [id_user], [is_paided], [is_delivered]) VALUES (5, 3, 1, 1) -- Employee
INSERT [dbo].[Order] ([id_order], [id_user], [is_paided], [is_delivered]) VALUES (6, 5, 1, 0) -- Support
SET IDENTITY_INSERT [dbo].[Order] OFF
GO

-- Order Items (at least 1 per order → 6+ rows)
SET IDENTITY_INSERT [dbo].[Order_list] ON
INSERT [dbo].[Order_list] ([id_order_list], [id_order], [id_product]) VALUES (1, 1, 1)
INSERT [dbo].[Order_list] ([id_order_list], [id_order], [id_product]) VALUES (2, 1, 2)
INSERT [dbo].[Order_list] ([id_order_list], [id_order], [id_product]) VALUES (3, 2, 3)
INSERT [dbo].[Order_list] ([id_order_list], [id_order], [id_product]) VALUES (4, 3, 4)
INSERT [dbo].[Order_list] ([id_order_list], [id_order], [id_product]) VALUES (5, 4, 5)
INSERT [dbo].[Order_list] ([id_order_list], [id_order], [id_product]) VALUES (6, 5, 6)
INSERT [dbo].[Order_list] ([id_order_list], [id_order], [id_product]) VALUES (7, 6, 1)
INSERT [dbo].[Order_list] ([id_order_list], [id_order], [id_product]) VALUES (8, 6, 2)
SET IDENTITY_INSERT [dbo].[Order_list] OFF
GO

-- Basket (6 basket items — mix of users)
SET IDENTITY_INSERT [dbo].[Basket] ON
INSERT [dbo].[Basket] ([id_basket], [id_user], [id_product], [count]) VALUES (1, 4, 1, 1)
INSERT [dbo].[Basket] ([id_basket], [id_user], [id_product], [count]) VALUES (2, 4, 3, 2)
INSERT [dbo].[Basket] ([id_basket], [id_user], [id_product], [count]) VALUES (3, 2, 4, 1)
INSERT [dbo].[Basket] ([id_basket], [id_user], [id_product], [count]) VALUES (4, 3, 5, 1)
INSERT [dbo].[Basket] ([id_basket], [id_user], [id_product], [count]) VALUES (5, 5, 6, 1)
INSERT [dbo].[Basket] ([id_basket], [id_user], [id_product], [count]) VALUES (6, 1, 2, 3) -- Admin testing
SET IDENTITY_INSERT [dbo].[Basket] OFF
GO