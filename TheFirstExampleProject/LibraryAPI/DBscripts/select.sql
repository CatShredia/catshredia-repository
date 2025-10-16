select * 
from Books b 
join Genres g on b.id_genre = g.id_genre;

select *
from Users u 
join Logins l on u.id_user = l.id_user;

select *
from RentLists rl;