USE [ShopDB]

-- город (уже есть в вашем скрипте)
INSERT INTO City (name)
VALUES 
('Казань'),
('Усть-Урюпинск'),
('Москва'),
('Липецк');

-- улица (уже есть в вашем скрипте)
INSERT INTO Street (name, id_city)
VALUES 
('Ленина', 1),
('Амирхана', 1),
('Большой Арбат', 3),  -- Москва имеет id = 3
('Малый Арбат', 3),   -- Москва имеет id = 3
('УУУ', 1),
('ЫЫЫ', 1),
('Название 1', 4),    -- Липецк имеет id = 4
('Название 2', 2);    -- Усть-Урюпинск имеет id = 2

-- таблица роли (уже есть в вашем скрипте)
INSERT INTO Role (name)
VALUES 
('admin'),
('employee'),
('user'),
('buyer');

-- таблица пользователь
INSERT INTO [User] (surname, name, desciption, phone, id_role)
VALUES 
('Иванов', 'Иван', 'Администратор магазина', '+7(999)111-11-11', 1),      -- admin
('Петров', 'Петр', 'Сотрудник склада', '+7(999)222-22-22', 2),           -- employee  
('Сидоров', 'Сергей', 'Постоянный покупатель', '+7(999)333-33-33', 4),    -- buyer
('Кузнецова', 'Анна', 'Новый пользователь', '+7(999)444-44-44', 3),       -- user
('Смирнов', 'Алексей', 'VIP клиент', '+7(999)555-55-55', 4);             -- buyer

-- таблица пользователь - адрес (UserAdresses)
INSERT INTO UserAdresses (id_user, id_street, home, apartment)
VALUES 
(1, 1, '10', 15),    -- Иванов, ул. Ленина, д.10, кв.15
(1, 2, '25', 33),    -- Иванов, ул. Амирхана, д.25, кв.33
(2, 3, '50', 12),    -- Петров, Большой Арбат, д.50, кв.12
(3, 4, '75', 8),     -- Сидоров, Малый Арбат, д.75, кв.8
(4, 5, '5', 22),     -- Кузнецова, ул. УУУ, д.5, кв.22
(5, 6, '15', NULL);  -- Смирнов, ул. ЫЫЫ, д.15, без квартиры

-- таблица логин
INSERT INTO Login ([login], [password], id_user)
VALUES 
('admin', 'admin123', 1),
('worker', 'worker123', 2),
('sergey', 'password123', 3),
('anna', 'mypassword', 4),
('alex', 'securepass', 5);

-- таблица продукта
INSERT INTO Product (name, price, provider, image_path)
VALUES 
('Смартфон iPhone 15', 85000, 'Apple Inc.', 'images/iphone15.jpg'),
('Ноутбук MacBook Air', 120000, 'Apple Inc.', 'images/macbook.jpg'),
('Наушники AirPods Pro', 25000, 'Apple Inc.', 'images/airpods.jpg'),
('Фитнес-браслет Mi Band 8', 3500, 'Xiaomi Corp.', 'images/miband8.jpg'),
('Электросамокат Xiaomi', 45000, 'Xiaomi Corp.', 'images/scooter.jpg'),
('Кофемашина DeLonghi', 32000, 'DeLonghi Group', 'images/coffee.jpg'),
('Беспроводная мышь Logitech', 2800, 'Logitech Inc.', 'images/mouse.jpg'),
('Механическая клавиатура', 7500, 'Razer Corp.', 'images/keyboard.jpg');