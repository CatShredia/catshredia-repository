-- 1. Insert roles
INSERT INTO public."Roles" ("name")
VALUES
    ('admin'),
    ('employee'),
    ('user');

-- 2. Insert sample users (one per role)
INSERT INTO public."Users" ("name", description, id_role)
VALUES
    ('Alice Admin', 'System administrator', 1),
    ('Bob Employee', 'Regular staff member', 2),
    ('Charlie User', 'End user with limited access', 3);

-- 3. Insert sample logins
INSERT INTO public."Logins" (login, "password", id_user)
VALUES
    ('alice', 'securePass123!', 1),
    ('bob', 'myPassword456', 2),
    ('charlie', 'userPass789', 3);

-- 1. Insert sample categories
INSERT INTO public."Categories" ("name", "description")
VALUES
    ('Electronics', 'description'),
    ('Books', 'description'),
    ('Clothing', 'description'),
    ('Home & Kitchen', 'description');

-- 2. Insert sample products
INSERT INTO public."Products" (
    "name",
    description,
    price,
    stroke,
    is_active,
    created_at,
    updated_at,
    id_category
)
VALUES
    ('Wireless Headphones', 'Noise-cancelling Bluetooth headphones', 129, 'black', true, '2025-10-25', '2025-10-25', 2),
    ('Smartphone Stand', 'Adjustable aluminum phone holder', 24, 'silver', true, '2025-10-26', '2025-10-26', 2),
    ('Learning C#', 'Comprehensive guide for .NET developers', 45, 'paperback', true, '2025-10-20', '2025-10-20', 2),
    ('Winter Jacket', 'Waterproof insulated jacket', 89, 'navy', false, '2025-09-15', '2025-10-10', 3),
    ('Coffee Maker', 'Programmable 12-cup drip coffee machine', 65, 'stainless', true, '2025-10-28', '2025-10-28', 4);

-- 1. Insert sample orders
-- Enum mapping: 
--   OrderStatus: preparing=0, delivering=1, delivered=2, canceled=3
--   OrderDeliveryType: car=0, helicopter=1, walkerman=2, deathstar=3

INSERT INTO public."Orders" (status, "deliveryType", address)
VALUES
    (0, 0, '123 Main St, Cityville'),
    (1, 1, '456 Oak Ave, Metropolis'),
    (2, 2, '789 Pine Rd, Gotham'),
    (3, 3, '0 Death Star, Galaxy Far Far Away');

-- 2. Insert sample order list items
-- Assumes you have products with id_product = 1, 2, 3, 4, 5 (from earlier script)

INSERT INTO public."OrderLists" (id_order, id_product)
VALUES
    (1, 12), -- Order 1 → Product 1
    (1, 13), -- Order 1 → Product 2
    (2, 14), -- Order 2 → Product 3
    (3, 15), -- Order 3 → Product 4
    (4, 16); -- Order 4 → Product 5
    
select * 
from "Users" u
join "Roles" r on u.id_role = r.id_role
join "Logins" l on l.id_user = u.id_user;

select *
from "Categories" c 
join "Products" p on c.id_category = p.id_category;

select * 
from "OrderLists" ol
right join "Orders" o on ol.id_order = o.id_order;

select * 
from "Sessions" s;