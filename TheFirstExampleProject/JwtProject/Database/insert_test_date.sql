-- Очистка данных (в порядке, безопасном для внешних ключей)

TRUNCATE TABLE public."OrderLists" RESTART IDENTITY CASCADE;
TRUNCATE TABLE public."Orders" RESTART IDENTITY CASCADE;
TRUNCATE TABLE public."Sessions" RESTART IDENTITY CASCADE;
TRUNCATE TABLE public."Logins" RESTART IDENTITY CASCADE;
TRUNCATE TABLE public."Users" RESTART IDENTITY CASCADE;
TRUNCATE TABLE public."Roles" RESTART IDENTITY CASCADE;
TRUNCATE TABLE public."Products" RESTART IDENTITY CASCADE;
TRUNCATE TABLE public."Categories" RESTART IDENTITY CASCADE;
TRUNCATE TABLE "OrderStatus" RESTART IDENTITY CASCADE;
TRUNCATE TABLE "OrderDeliveryType" RESTART IDENTITY CASCADE;

-- 1. Insert roles
INSERT INTO public."Roles" ("name")
VALUES ('admin'),
       ('employee'),
       ('user');

-- 2. Insert sample users (one per role)
INSERT INTO public."Users" ("name", description, id_role)
VALUES ('Alice Admin', 'System administrator', 1),
       ('Bob Employee', 'Regular staff member', 2),
       ('Charlie User', 'End user with limited access', 3);

-- 3. Insert sample logins
INSERT INTO public."Logins" (login, "password", id_user)
VALUES ('alice', 'securePass123!', 1),
       ('bob', 'myPassword456', 2),
       ('charlie', 'userPass789', 3);

-- Insert OrderStatus
INSERT INTO "OrderStatus" ("id_status", "name")
VALUES (1, 'preparing'),
       (2, 'delivering'),
       (3, 'delivered'),
       (4, 'canceled'),
       (5, 'basket');

-- Insert OrderDeliveryType
INSERT INTO "OrderDeliveryType" ("id_delivery_type", "name")
VALUES (1, 'car'),
       (2, 'helicopter'),
       (3, 'walkerman'),
       (4, 'deathstar');

-- Insert sample categories
INSERT INTO public."Categories" ("name", "description")
VALUES ('Electronics', 'description'),
       ('Books', 'description'),
       ('Clothing', 'description'),
       ('Home & Kitchen', 'description');

-- Insert sample products
INSERT INTO public."Products" ("name",
                               description,
                               price,
                               stroke,
                               is_active,
                               created_at,
                               updated_at,
                               id_category)
VALUES ('Wireless Headphones', 'Noise-cancelling Bluetooth headphones', 129, 'black', true, '2025-10-25', '2025-10-25',
        1),
       ('Smartphone Stand', 'Adjustable aluminum phone holder', 24, 'silver', true, '2025-10-26', '2025-10-26', 1),
       ('Learning C#', 'Comprehensive guide for .NET developers', 45, 'paperback', true, '2025-10-20', '2025-10-20', 2),
       ('Winter Jacket', 'Waterproof insulated jacket', 89, 'navy', false, '2025-09-15', '2025-10-10', 3),
       ('Coffee Maker', 'Programmable 12-cup drip coffee machine', 65, 'stainless', true, '2025-10-28', '2025-10-28',
        4);

-- Insert sample orders
INSERT INTO public."Orders" ("id_status", "id_delivery_type", "id_user", address)
VALUES (1, 1, 1, '123 Main St, Cityville'),
       (2, 2, 2, '456 Oak Ave, Metropolis'),
       (3, 3, 3, '789 Pine Rd, Gotham'),
       (4, 4, 3, '0 Death Star, Galaxy Far Far Away');

-- Insert sample order list items
INSERT INTO public."OrderLists" (id_order, id_product)
VALUES (1, 1),
       (1, 2),
       (2, 3),
       (3, 4),
       (4, 5);

SELECT *
FROM "Users" u
         JOIN "Roles" r ON u.id_role = r.id_role
         JOIN "Logins" l ON l.id_user = u.id_user;

SELECT *
FROM "Categories" c
         JOIN "Products" p ON c.id_category = p.id_category;

SELECT *
FROM "OrderLists" ol
         RIGHT JOIN "Orders" o ON ol.id_order = o.id_order;

select *
from "Orders" o
         join "OrderStatus" os on o.id_status = os.id_status
         join "OrderDeliveryType" od on o.id_status = od.id_delivery_type;

SELECT *
FROM "Sessions" s;