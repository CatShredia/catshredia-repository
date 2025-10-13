-- Подключаемся к базе (если запускаете отдельно)

-- Roles (6 roles)
INSERT INTO role (id_role, name) VALUES
(1, 'Admin'),
(2, 'Manager'),
(3, 'Employee'),
(4, 'Customer'),
(5, 'Support'),
(6, 'Guest');

-- Role Permissions
INSERT INTO role_permission (id_role, permission_name) VALUES
(1, 'Employee.CRUD'),
(1, 'Users.CRUD'),
(1, 'Product.CRUD'),
(1, 'AllOrder'),
(2, 'Users.RUD'),
(2, 'Product.CRUD'),
(2, 'OrderList.R'),
(2, 'AllOrder'),
(3, 'Product.R'),
(3, 'OrderList.R'),
(3, 'Catalog.CRUD'),
(4, 'Catalog.CRUD'),
(4, 'OrderList.CRUD'),
(5, 'Users.R'),
(5, 'OrderList.R');
-- Guest has no permissions

-- Cities (6 cities)
INSERT INTO city (id_city, name) VALUES
(1, 'Moscow'),
(2, 'Saint Petersburg'),
(3, 'Novosibirsk'),
(4, 'Yekaterinburg'),
(5, 'Kazan'),
(6, 'Nizhny Novgorod');

-- Streets (6 streets — 1 per city)
INSERT INTO street (id_street, name, id_city) VALUES
(1, 'Tverskaya', 1),
(2, 'Nevsky Prospect', 2),
(3, 'Krasny Avenue', 3),
(4, 'Lenina Street', 4),
(5, 'Bauman Street', 5),
(6, 'Bolshaya Pokrovskaya', 6);

-- Users (6 users — one per role)
INSERT INTO app_user (id_user, surname, name, description, phone, id_role) VALUES
(1, 'Ivanov', 'Ivan', 'System admin', '+79001111111', 1),
(2, 'Petrov', 'Petr', 'Store manager', '+79002222222', 2),
(3, 'Sidorov', 'Sergey', 'Warehouse employee', '+79003333333', 3),
(4, 'Kuznetsova', 'Anna', 'Regular customer', '+79004444444', 4),
(5, 'Morozov', 'Dmitry', 'Support specialist', '+79005555555', 5),
(6, 'Guest', 'User', 'Guest account', NULL, 6);

-- User Addresses (6 addresses — one per user)
INSERT INTO user_address (id_user_address, id_user, id_street, home, apartment) VALUES
(1, 1, 1, '10', 5),
(2, 2, 2, '25', 12),
(3, 3, 3, '50', 3),
(4, 4, 4, '77', 21),
(5, 5, 5, '33', 8),
(6, 6, 6, '1', NULL); -- Guest has no apartment

-- Logins (6 logins — one per user)
INSERT INTO login (id_login, login, password, id_user) VALUES
(1, 'admin', 'admin123', 1),
(2, 'manager', 'manager123', 2),
(3, 'employee', 'emp123', 3),
(4, 'customer', 'cust123', 4),
(5, 'support', 'supp123', 5),
(6, 'guest', 'guest123', 6);

-- Products (6 products)
INSERT INTO product (id_product, name, price, provider, image_path) VALUES
(1, 'Laptop', 50000, 'Dell', '/images/laptop.jpg'),
(2, 'Mouse', 1500, 'Logitech', '/images/mouse.jpg'),
(3, 'Keyboard', 2500, 'Razer', '/images/keyboard.jpg'),
(4, 'Monitor', 12000, 'Samsung', '/images/monitor.jpg'),
(5, 'Headphones', 3500, 'Sony', '/images/headphones.jpg'),
(6, 'Webcam', 4000, 'Logitech', '/images/webcam.jpg');

-- Orders (6 orders — mostly for customer & manager)
INSERT INTO shop_order (id_order, id_user, is_paid, is_delivered) VALUES
(1, 4, true, true),   -- Customer
(2, 4, true, false),
(3, 2, true, true),   -- Manager
(4, 2, false, false),
(5, 3, true, true),   -- Employee
(6, 5, true, false);  -- Support

-- Order Items (8 items for 6 orders)
INSERT INTO order_item (id_order_item, id_order, id_product) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 2, 3),
(4, 3, 4),
(5, 4, 5),
(6, 5, 6),
(7, 6, 1),
(8, 6, 2);

-- Basket (6 basket items — mix of users)
INSERT INTO basket (id_basket, id_user, id_product, count) VALUES
(1, 4, 1, 1),
(2, 4, 3, 2),
(3, 2, 4, 1),
(4, 3, 5, 1),
(5, 5, 6, 1),
(6, 1, 2, 3); -- Admin testing