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

select * 
from "Users" u
join "Roles" r on u.id_role = r.id_role
join "Logins" l on l.id_user = u.id_user;