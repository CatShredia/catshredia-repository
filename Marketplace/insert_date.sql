-- Countries
INSERT INTO
    "Country" (name)
VALUES
    ('Россия'),
    ('Казахстан'),
    ('Беларусь');

-- Cities
INSERT INTO
    "City" (name, countryid)
VALUES
    ('Москва', 1),
    ('Санкт-Петербург', 1),
    ('Новосибирск', 1),
    ('Алматы', 2),
    ('Минск', 3);

-- Streets
INSERT INTO
    "Street" (name, cityid)
VALUES
    ('Тверская', 1),
    ('Невский проспект', 2),
    ('Красный проспект', 3),
    ('Проспект Абая', 4),
    ('Притыцкого', 5);

-- Addresses
INSERT INTO
    "Address" (housenumber, corpus, apartment, streetid)
VALUES
    ('10', NULL, NULL, 1),
    ('50', 'А', '12', 2),
    ('100', NULL, NULL, 3),
    ('77', NULL, NULL, 4),
    ('25', 'Б', '33', 5);

-- Warehouses
INSERT INTO
    "Warehouse" (name, addressid)
VALUES
    ('Склад Москва-Центр', 1),
    ('Склад СПб', 2),
    ('Склад Новосибирск', 3),
    ('Склад Алматы', 4),
    ('Склад Минск', 5);

-- Users
INSERT INTO
    "User" (login, password, createdat, editedat)
VALUES
    (
        'ivan_ivanov',
        'hashed_password_1',
        '2025-01-01',
        '2025-10-10'
    ),
    (
        'petr_petrov',
        'hashed_password_2',
        '2025-01-01',
        '2025-10-10'
    ),
    (
        'alex_kaz',
        'hashed_password_3',
        '2025-01-01',
        '2025-10-10'
    ),
    (
        'anna_bel',
        'hashed_password_4',
        '2025-01-01',
        '2025-10-10'
    );

-- Sellers (must reference existing Users)
INSERT INTO
    "Seller" (userid)
VALUES
    (2),
    (3),
    (4),
    (5);

-- Categories
INSERT INTO
    "Category" (name)
VALUES
    ('Электроника'),
    ('Одежда'),
    ('Книги'),
    ('Бытовая техника');

-- Tags
INSERT INTO
    "Tag" (name)
VALUES
    ('Новинка'),
    ('Хит продаж'),
    ('Распродажа'),
    ('Бесплатная доставка');

-- Products
INSERT INTO
    "Product" (
        sku,
        title,
        description,
        sellerid,
        categoryid,
        createdat,
        editedat
    )
VALUES
    (
        'EL-001',
        'Смартфон XYZ',
        'Флагманский смартфон с OLED-экраном',
        5,
        1,
        '2025-01-01',
        '2025-10-10'
    ),
    (
        'CL-002',
        'Куртка зимняя',
        'Теплая водонепроницаемая куртка',
        6,
        2,
        '2025-01-01',
        '2025-10-10'
    ),
    (
        'BK-003',
        'Война и мир',
        'Классика русской литературы',
        7,
        3,
        '2025-01-01',
        '2025-10-10'
    ),
    (
        'AP-004',
        'Микроволновка FastHeat',
        'Мощная микроволновка 25л',
        8,
        4,
        '2025-01-01',
        '2025-10-10'
    );

-- Product-Tag links
INSERT INTO
    "ProductTag" (productid, tagid)
VALUES
    (6, 1),
    (7, 2),
    (8, 3),
    (9, 4);

-- Inventory (must reference valid Product + Warehouse)
INSERT INTO
    "Inventory" (productid, warehouseid, quantity, reserved)
VALUES
    (6, 1, 50, 5),
    (7, 2, 30, 2),
    (8, 1, 100, 10),
    (9, 5, 200, 0),
    (4, 3, 25, 3);

-- Inventory Transactions (TxnType: 0=In, 1=Out, 2=Adjust, 3=Reserved, 4=Unreserved)
INSERT INTO
    "InventoryTransaction" (
        inventoryid,
        txntype,
        quantity,
        batchid,
        costperunit
    )
VALUES
    (
        1,
        0,
        50,
        'a1b2c3d4-e5f6-7890-1234-567890abcdef',
        25000.00
    ),
    (
        2,
        0,
        30,
        'a1b2c3d4-e5f6-7890-1234-567890abcdef',
        25000.00
    ),
    (
        3,
        0,
        100,
        'b2c3d4e5-f6a7-8901-2345-67890abcdef1',
        5000.00
    ),
    (
        4,
        0,
        200,
        'c3d4e5f6-a7b8-9012-3456-7890abcdef12',
        800.00
    ),
    (
        5,
        0,
        25,
        'd4e5f6a7-b8c9-0123-4567-890abcdef123',
        12000.00
    );