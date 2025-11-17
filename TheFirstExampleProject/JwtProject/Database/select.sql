select s.id_session, s."name", u."name"
from "Sessions" s
         join "Users" u on s.id_user = u.id_user;

select u."name",
       l.login,
       l."password",
       r."name"
from "Users" u
         join "Logins" l on u.id_user = l.id_user
         join "Roles" r on r.id_role = u.id_role;

select *
from "Logs" l;